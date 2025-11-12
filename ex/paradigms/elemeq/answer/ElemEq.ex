defmodule ElemEq do
  def compare([], []) do
    []
  end
  def compare([a_head|a_tail], [b_head|b_tail]) do
    [a_head==b_head|compare(a_tail,b_tail)]
  end
end

test_suite = [
  {[], []},
  {[1,2,3], [1,2,3]},
  {[1,2,3], [2,3,1]},
  {[1.0], [1]},
  {["hello", "world"], ["goodbye", "world"]},
  {[1, "a", 2, "b"], [1, "a", 2, "B"]},
]

Enum.map(test_suite, fn {a, b} -> ElemEq.compare(a, b) end)
