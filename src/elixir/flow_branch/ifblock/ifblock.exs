#!/usr/bin/env elixir

input = 3
IO.puts("input is #{input}")
input =
  if rem(input, 2)==1 do
    IO.puts("input is odd. Let me fix that for you ...")
    input + 1
  else
    input
  end
IO.puts("input is #{input}")
