#!/usr/bin/env elixir

colormap = %{
  "elixir" => "violet",
  "csharp" => "blue",
  "python" => "orange",
  "example" => "teal",
}

sections = [
  "section",
  "subsection",
  "subsubsection",
]

defmodule Script do
  def run(colormap, sections) do
    colormap
    |> Enum.map(fn {name, color} ->
      "% #{name}\n"<>
      (
        sections
        |> Enum.map(fn section ->
          """
          \\newcommand{\\#{name}#{section}}[1]{
            \\#{section}{#1}
            \\begin{tikzpicture}[remember picture,overlay]
              \\node[
                anchor=east,
                fill=#{color},
                minimum width=12mm,
                minimum height=4mm,
              ] at (0,9mm -| current page.east) {};
            \\end{tikzpicture}
          }
          """
        end)
        |> Enum.join("")
      )
      <>"\n"
    end)
    |> Enum.join("")
    |> IO.puts()
  end
end

Script.run(colormap, sections)
