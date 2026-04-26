#!/usr/bin/env elixir

defmodule Script do
  @scale 5
  
  defp generate_points(0, _reference, result), do: result
  defp generate_points(number, reference, result) do
    x = @scale*(:rand.uniform()-0.5)
    y = @scale*(:rand.uniform()-0.5)
    r = :math.sqrt(x**2+y**2)
    if r<0.7*@scale/2 do
      x = :erlang.float_to_binary(x, [:compact, decimals: 10])
      y = :erlang.float_to_binary(y, [:compact, decimals: 10])
      line = "    \\node[point] () at ([xshift=#{x}cm,yshift=#{y}cm]#{reference}.center) {};\n"
      generate_points(number-1, reference, [line|result])
    else
      generate_points(number, reference, result)
    end
  end
  
  def single(reference) do
    generate_points(16, reference, [])
    |> Enum.join("")
    |> IO.puts()
  end
  
  def run() do
    ["src", "dst"]
    |> Enum.map(&single/1)
  end
end

Script.run()
