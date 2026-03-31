#!/usr/bin/env elixir

_filename = "../doc/document.tex"
filename = "/tmp/test.tex"

defmodule ScanEntry do
  defstruct re: nil, handler: nil, params: nil
end

defmodule Scanner do
  # @spec match(list(ScanEntry), list(ScanEntry), list(any()), binary(), boolean()) :: {list(any()), binary()}
  defp match(_rest, _all, acc, "", _skippable), do: {acc, ""}

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
      match(rest, all, acc, input, skippable)
    else
      l = r |> Enum.at(0) |> String.length()
      acc = handler.(r, params, acc)
      input = String.slice(input, l..-1//1)
      match(all, all, acc, input, skippable)
    end
  end

  def process(machine, input, skippable, acc \\ []) do
    {res, rest} = match(machine, machine, acc, input, skippable)
    {Enum.reverse(res), rest}
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
        handler: fn [_ | [filename | _]], _params, acc ->
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

    Scanner.process(machine, contents, true)
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
  defp parse(contents, :outer = _state) do
    machine = [
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

    Scanner.process(machine, contents, false, %{output: "", state: :outer})
  end

  def process(filename, _params) do
    IO.puts("CS Processing '#{filename}'")

    result =
      filename
      |> File.read!()
      |> parse(:outer)

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
