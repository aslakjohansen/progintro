double value = 1.234; // m
Unit unit = Unit.MilliMeter;

switch (unit) {
  case Unit.Meter:
    value *= 1;
    break;
  case Unit.CentiMeter:
    value *= 100;
    break;
  case Unit.MilliMeter:
    value *= 1000;
    break;
  case Unit.Inches:
    value *= 100 / 2.54;
    break;
  default:
    Console.WriteLine("Oh, no!");
    break;
}

Console.WriteLine("Result is "+value);

enum Unit {
  Meter,
  CentiMeter,
  MilliMeter,
  Inches,
}
