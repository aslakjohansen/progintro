#!/usr/bin/env elixir

[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
|> Enum.map(fn value -> value + 1 end)
|> IO.inspect(charlists: :as_lists)
