humans
|> Enum.filter(fn human -> human.sex == :male and human.age >= 18 end)
|> Enum.map(fn human -> human.age end)
|> Enum.min()
