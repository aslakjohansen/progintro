#!/usr/bin/env elixir

incr = fn value -> value + 1 end

[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
|> Enum.map(incr)
|> IO.inspect(charlists: :as_lists)
