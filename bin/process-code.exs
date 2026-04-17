#!/usr/bin/env elixir

_filename = "../doc/document.tex"
filename = "/tmp/repo/doc/test.tex"

defmodule ScanEntry do
  defstruct re: nil, handler: nil, params: nil
end

# Scanner.match interface:
# - Input: 
#   - list of remaining ScanEntry
#   - list of all ScanEntry
#   - accumulator
#   - remaining input string
#   - skippable: bool for whether single characters should be skipped is no match is found
# - output: {res, rest}
#   - res: our accumulator
#   - rest: remaining (unmatched) input
# 
# ScanEntry.handler interface:
# - Input:
#   - result of Regex.run: list of full match, followed by individual match sites
#   - parameters from ScanEntry (usually empty)
#   - accumulator
# - Output:
#   - accumulator
# 
# An accumulator given through an initial call is repeatedly passed to (and returned from) the handlers from the various ScanEntrys'. These are attempted matched according to the order provided. The final accumulator is returned from Scanner.match along with the unmatched remainder of the input. This should allow the caller to pass the remainder to another call to Scanner.match according to a state managed within the accumulator.
# 
# This means that the accumulator has (at least) two functions:
# - keep state throughout the entire matching sequence
# - keep the (likely growing) output
defmodule Scanner do
  # @spec match(list(ScanEntry), list(ScanEntry), list(any()), binary(), boolean()) :: {list(any()), binary()}
  defp match(_rest, _all, acc, input, _skippable) when input == "", do: {acc, input}

  defp match([], all, acc, input, skippable) when skippable == true do
    match(all, all, acc, String.slice(input, 1..-1//1), skippable)
  end

  defp match([], _all, acc, input, skippable) when skippable == false do
    {acc, input}
  end

  defp match([first | rest], all, acc, input, skippable) do
    %{re: re, handler: handler, params: params} = first

    r = Regex.run(re, input)

    if r == nil do
      IO.puts("failed match input='#{input}'")
      IO.inspect(re)
      match(rest, all, acc, input, skippable)
    else
      IO.inspect(acc)
      IO.puts("calling handler")
      acc = handler.(r, params, acc)
      IO.puts("handler returns")
      IO.inspect(acc)
      l = r |> Enum.at(0) |> String.length()
      input = String.slice(input, l..-1//1)
      match(all, all, acc, input, skippable)
    end
  end

  def process(machine, input, skippable, acc) do
    {res, rest} = match(machine, machine, acc, input, skippable)
    {res, rest}
    # removed a referse here
  end
end

defmodule Tex do
  defp langmap("C"), do: "c"
  defp langmap("Csharp"), do: "csharp"
  defp langmap("Elixir"), do: "elixir"
  defp langmap("Python"), do: "python"

  defp parse(contents) do
    machine = [
      %ScanEntry{
        re: ~r/^\\input{([^}#]+)}/,
        handler: fn [_, filename], _params, acc ->
          process(filename) ++ acc
        end
      },
      %ScanEntry{
        re: ~r/^\\include([^}]+)File{([^}#]+)}{([^}#]+)}/,
        handler: fn [_, lang, minted_params, filename], _params, acc ->
          lang = langmap(lang)
          filename = "../src/#{lang}/#{filename}"
          [{:job, lang, filename, minted_params} | acc]
        end
      },
      %ScanEntry{
        re: ~r/^\\include([^}]+)File{([^}#]+)}/,
        handler: fn [_, lang, filename], _params, acc ->
          lang = langmap(lang)
          filename = "../src/#{lang}/#{filename}"
          [{:job, lang, filename, ""} | acc]
        end
      }
    ]

    Scanner.process(machine, contents, true, [])
    |> elem(0)
  end

  def process(filename) do
    IO.puts("Processing '#{filename}'")

    filename
    |> File.read!()
    |> parse()
  end
end

defmodule CsharpHandler do
  defp parse(contents, %{state: [:outer | _], output: _output} = acc) do
    machine = [
      %ScanEntry{
        re: ~r/^(\s+)/,
        handler: fn [_full, match], _params, %{output: output, state: state} = acc ->
          IO.puts("CsharpHandler.parse outer whitespace output='#{output}' match='#{match}'")
          IO.inspect(acc)

          %{output: output <> match, state: state}
        end
      },
      %ScanEntry{
        re: ~r/^([a-zA-Z0-9_]+)(\s+)([a-zA-Z0-9_]+)(\s*=)/,
        handler: fn [_full, type, space, name, ending],
                    _params,
                    %{output: output, state: state} = _acc ->
          ext = "#{type}#{space}#{name}#{ending}"
          IO.puts("CsharpHandler.parse outer assignment output='#{output}' ext='#{ext}'")
          %{output: output <> ext, state: [:expr | state]}
        end
      },
      %ScanEntry{
        re: ~r/^([a-zA-Z0-9_]+)(\s+)([a-zA-Z0-9_]+)(\s*;)/,
        handler: fn [_full, type, space, name, ending],
                    _params,
                    %{output: output, state: state} = _acc ->
          ext = "#{type}#{space}#{name}#{ending}"
          %{output: output <> ext, state: state}
        end
      }
    ]

    {acc, rest} = Scanner.process(machine, contents, false, acc)
    IO.puts("returns:")
    IO.inspect(rest)
    IO.inspect(acc)
    {acc, rest}
    # parse(rest, acc)
    # we need to somehow process the :expr that has been prepended
  end

  defp parse(contents, %{state: [:expr | last_state], output: _output} = acc) do
    machine = [
      %ScanEntry{
        re: ~r/^(\s+)/,
        handler: fn [_full, match], _params, %{output: output, state: state} = _acc ->
          IO.puts("CsharpHandler.parse expr space output='#{output}' match='#{match}'")
          %{output: output <> match, state: state}
        end
      },
      %ScanEntry{
        re: ~r/^(\d+|\d+\.\d+)/,
        handler: fn [_full, match], _params, %{output: output, state: state} = _acc ->
          IO.puts("##############################################################")
          IO.puts("CsharpHandler.parse expr number output='#{output}' match='#{match}'")
          %{output: output <> match, state: state}
        end
      },
      %ScanEntry{
        re: ~r/^(;)/,
        handler: fn [_full, match], _params, %{output: output, state: _state} = _acc ->
          IO.puts("CsharpHandler.parse expr scolon output='#{output}' match='#{match}'")
          %{output: output <> match, state: last_state}
        end
      }
    ]

    {_acc, _rest} = Scanner.process(machine, contents, false, acc)
    # parse(rest, acc)
  end

  def process(filename, _params) do
    IO.puts("CS Processing '#{filename}'")

    result =
      filename
      |> File.read!()
      |> parse(%{state: [:outer], output: ""})

    {:handled, result}
  end
end

defmodule DumbHandler do
  def process(_filename, _params) do
    {:skipped}
  end
end

defmodule Script do
  def run(filename) do
    handlers = %{
      "c" => DumbHandler,
      "csharp" => CsharpHandler,
      "python" => DumbHandler,
      "elixir" => DumbHandler
    }

    jobs =
      filename
      |> Tex.process()
      |> Enum.map(fn job ->
        case job do
          {:job, lang, filename, params} ->
            handler = Map.get(handlers, lang)
            handler.process(filename, params)
        end
      end)

    IO.inspect(jobs)
  end
end

Script.run(filename)
