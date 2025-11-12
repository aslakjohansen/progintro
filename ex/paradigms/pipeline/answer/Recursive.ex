defmodule Algorithm do
  def solve(humans) do
    solve(humans, None)
  end
  
  defp solve([human], best) do
    incorporate(best, human)
  end
  defp solve([human|rest], best) do
    new_best = incorporate(best, human)
    solve(rest, new_best)
  end

  defp incorporate(best, contender) do
    if contender.sex==:male and contender.age>=18 and (best==None or contender.age<best) do
      contender.age
    else
      best
    end
  end
end
