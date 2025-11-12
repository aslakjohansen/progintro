defmodule Human do
  defstruct sex: :female, age: 0, name: "Buffy Summers"
end

humans =
  [
    %Human{age: 17},
    %Human{sex: :male, age: 12, name: "Luca"},
    %Human{sex: :female, age: 22, name: "Sofie"},
    %Human{sex: :male, age: 34, name: "Klaus"},
    %Human{sex: :female, age: 19, name: "Perinne"},
    %Human{sex: :female, age: 23, name: "Fie"},
    %Human{sex: :male, age: 20, name: "Asger"},
    %Human{sex: :female, age: 27, name: "Pernile"},
    %Human{sex: :male, age: 21, name: "Peter"},
    %Human{sex: :female, age: 26, name: "Dominika"},
    %Human{sex: :male, age: 7, name: "Mathias"},
  ]
