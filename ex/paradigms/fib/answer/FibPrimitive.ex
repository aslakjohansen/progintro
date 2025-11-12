defmodule FibPrimitive do
  
  def calc(0) do
    0
  end
  
  def calc(1) do
    1
  end
  
  def calc(n) when n>0 do
    calc(n-1) + calc(n-2)
  end
  
end
