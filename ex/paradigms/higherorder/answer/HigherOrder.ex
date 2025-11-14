defmodule HigherOrder do
  def map([], _fun) do
    []
  end
  def map([head|tail], fun) do
    [
      fun.(head)
    |
      map(tail, fun)
    ]
  end
  
  def filter([], _fun) do
    []
  end
  def filter([head|tail], fun) do
    if fun.(head) do
      [head|filter(tail, fun)]
    else
      filter(tail, fun)
    end
  end
end

test = [1,5,-12,-845,23,-1,14,16,2,35,-53,243,4,2,6,-1,-42]

test
|> HigherOrder.filter(fn value -> value>0 end)
|> HigherOrder.map(fn value -> value+1 end)

