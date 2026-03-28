#!/usr/bin/env elixir

filename = "../doc/document.tex"

defmodule ScanEntry do
  defstruct re: nil, handler: nil, context: nil
end

defmodule Scanner do
  @spec match(list(ScanEntry), list(ScanEntry), binary(), list(any())) :: list(any())
  defp match(_rest, _all, "", output), do: output

  defp match([], all, input, output) do
    match(all, all, String.slice(input, 1..-1//1), output)
  end

  defp match([first | rest], all, input, output) do
    %{re: re, handler: handler, context: context} = first

    r = Regex.run(re, input)

    if r == nil do
      match(rest, all, input, output)
    else
      l = r |> Enum.at(0) |> String.length()
      result = handler.(context, r)
      output = [result | output]
      input = String.slice(input, l..-1//1)
      match(all, all, input, output)
    end
  end

  def process(machine, input) do
    match(machine, machine, input, [])
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
        handler: fn _context, [_ | [filename | _]] ->
          # {:file, filename, process(filename)}
          process(filename)
        end
      },
      %ScanEntry{
        re: ~r/^\\include([^}]+)File{([^}#]+)}{([^}#]+)}/,
        handler: fn _context, [_, lang, minted_params, filename] ->
          lang = langmap(lang)
          filename = "../src/#{lang}/#{filename}"
          {:job, lang, filename, minted_params}
        end
      },
      %ScanEntry{
        re: ~r/^\\include([^}]+)File{([^}#]+)}/,
        handler: fn _context, [_, lang, filename] ->
          lang = langmap(lang)
          filename = "../src/#{lang}/#{filename}"
          {:job, lang, filename, ""}
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

defmodule Script do
  def run(filename) do
    jobs =
      filename
      |> Tex.process()
      |> List.flatten()

    IO.inspect(jobs)
  end
end

Script.run(filename)
