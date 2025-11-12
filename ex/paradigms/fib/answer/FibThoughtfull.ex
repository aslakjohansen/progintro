defmodule FibThoughtfull do
  
  def calc(n) when n>=0 do
    calc(0, 1, n)
  end
  
  defp calc(last, _last_last, 0) do
    last
  end
  
  defp calc(last, last_last, ttl) when ttl>0 do
    calc(last+last_last, last, ttl-1)
  end
  
end
