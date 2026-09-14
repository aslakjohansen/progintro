defmodule Math do
  @doc """
  Returns sum of the furst and the second arguments.

  ## Examples:

    iex> Math.add(1, 2)
    3

    iex> Math.add(1, -1)
    0

    iex> Math.add(-1, 1)
    1
  """
  def add(a, b) do
    a + b
  end

  @doc """
  Returns the first argument divided by the second.

  ## Examples:

    iex> Math.div(1, 10)
    0.1

    iex> Math.div(1, 0)
    ** (ArithmeticError) bad argument in arithmetic expression
  """
  def div(a, b) do
    a / b
  end
end
