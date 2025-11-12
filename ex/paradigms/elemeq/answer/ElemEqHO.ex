test_suite = [
  {[], []},
  {[1,2,3], [1,2,3]},
  {[1,2,3], [2,3,1]},
  {[1.0], [1]},
  {["hello", "world"], ["goodbye", "world"]},
  {[1, "a", 2, "b"], [1, "a", 2, "B"]},
]

Enum.map(test_suite, fn {a, b} -> Enum.zip(a, b) |> Enum.map(fn {a,b} -> a==b end) end)
