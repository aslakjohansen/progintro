#!/usr/bin/env elixir

filename = "../doc/document.tex"

defmodule ScanEntry do
  defstruct re: nil, handler: nil, params: nil
end

defmodule Scanner do
  @spec match(list(ScanEntry), list(ScanEntry), list(any()), binary()) :: list(any())
  defp match(_rest, _all, acc, ""), do: acc

  defp match([], all, acc, input) do
    match(all, all, acc, String.slice(input, 1..-1//1))
  end

  defp match([first | rest], all, acc, input) do
    %{re: re, handler: handler, params: params} = first

    r = Regex.run(re, input)

    if r == nil do
      match(rest, all, acc, input)
    else
      l = r |> Enum.at(0) |> String.length()
      acc = handler.(r, params, acc)
      input = String.slice(input, l..-1//1)
      match(all, all, acc, input)
    end
  end

  def process(machine, input) do
    match(machine, machine, [], input)
    |> Enum.reverse()
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

    Scanner.process(machine, contents)
  end

  def process(filename) do
    IO.puts("Processing '#{filename}'")

    filename
    |> File.read!()
    |> parse()
  end
end

defmodule CsharpHandler do
  def process(_filename, _params) do
    :handled
  end
end

defmodule DumbHandler do
  def process(_filename, _params) do
    :skipped
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
