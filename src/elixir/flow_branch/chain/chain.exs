#!/usr/bin/env elixir

input = "N"

result =
  cond do
    input == "N" -> "Going north ..."
    input == "S" -> "Going south ..."
    input == "E" -> "Going east ..."
    input == "W" -> "Going west ..."
    true -> ""
  end

IO.puts(result)
