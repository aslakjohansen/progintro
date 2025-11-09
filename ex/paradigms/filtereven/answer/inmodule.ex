defmodule Filter do
  def filter([]) do
    []
  end
  def filter([head|tail]) when is_integer(head) do
    if rem(head,2)==0 do
      [head|filter(tail)]
    else
      filter(tail)
    end
  end
end

[1,5,-12,-845,23,-1,14,16,2,35,-53,243,4,2,6,-1,-42]
|> Filter.filter()
