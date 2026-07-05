#!/usr/bin/env elixir

input = "N"

result =
  case input do
    "N" -> "Going north ..."
    "S" -> "Going south ..."
    "E" -> "Going east ..."
    "W" -> "Going west ..."
    _ -> "I don't understand ?!?"
  end

IO.puts(result)
