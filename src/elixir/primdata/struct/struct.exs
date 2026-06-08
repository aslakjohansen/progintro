#!/usr/bin/env elixir

# NOTE: This is not executable

defmodule Door do
  defstruct open: false, height: 230, width: 110
end

door = %Door{open: true, height: 220}

IO.puts(door.width)
