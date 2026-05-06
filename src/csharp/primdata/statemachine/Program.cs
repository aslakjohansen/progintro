Category get_category (string input) {
  Category state = Category.Unknown;
  
  foreach (char c in input) {
    switch (state) {
    case Category.Unknown:
      if (c=='.') {
        state = Category.Float;
      } else if (Char.IsDigit(c)) {
        state = Category.Integer;
      } else {
        state = Category.String;
      }
      break;
    case Category.Integer:
      if (c=='.') {
        state = Category.Float;
      } else if (!Char.IsDigit(c)) {
        state = Category.String;
      }
      break;
    case Category.Float:
      if (c=='.' || !Char.IsDigit(c)) {
        state = Category.String;
      }
      break;
    case Category.String:
      break;
    default:
      Console.WriteLine("Error, unknown state: "+state);
      break;
    }
  }
  
  return state;
}

string[] inputs = new string[] {
  "10.h",
  "10.7",
  "10",
  "Hello, world"
};

foreach (string input in inputs) {
  Category category = get_category(input);
  Console.WriteLine(category);
}

enum Category {
  Unknown,
  String,
  Integer,
  Float,
}
