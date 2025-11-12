# convenience alias
alias VegaLite, as: Vl

# module for timing 
defmodule Timer do
  def measure(f, inputs, label) do
    inputs
    |> Enum.map(
      fn input ->
        {time, _} = :timer.tc(f, [input])
        %{
          "n" => input,
          "time" => time,
          "implementation" => label,
        }
      end
    )
  end
end

# perform timing measurements
inputs = 0..40
measurements_primitive = Timer.measure(&FibPrimitive.calc/1, inputs, "Primitive")
measurements_thoughtfull = Timer.measure(&FibThoughtfull.calc/1, inputs, "Thoughtfull")
measurements = measurements_primitive ++ measurements_thoughtfull

# plot results
Vl.new(width: 400, height: 300)
|> Vl.data_from_values(measurements)
|> Vl.mark(:line)
|> Vl.encode_field(:x, "n", type: :quantitative, title: "n/[n]")
|> Vl.encode_field(:y, "time", type: :quantitative, title: "Time/[us]")
|> Vl.encode_field(:color, "implementation", type: :nominal, title: "Implementation")
