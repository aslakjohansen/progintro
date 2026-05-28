#!/usr/bin/env elixir

incr = fn value -> value + 1 end
11 |> incr.() |> incr.()
