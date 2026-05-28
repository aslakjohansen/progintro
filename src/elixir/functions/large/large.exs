#!/usr/bin/env elixir

incr = fn value -> value + 1 end
possitive = fn value -> value > 0 end

[0, 2, -1, -5, 12, 7, 0, 1, -6]
|> Enum.map(incr)
|> Enum.filter(possitive)
|> Enum.reduce(0, fn value, acc -> max(value, acc) end)
|> IO.inspect(charlists: :as_lists)
