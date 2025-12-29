// init
double[] factors = new double[(int)Unit.Size];
factors[(int)Unit.Meter] = 1;
factors[(int)Unit.CentiMeter] = 100;
factors[(int)Unit.MilliMeter] = 1000;
factors[(int)Unit.Inches] = 100 / 2.54;

double value = 1.234; // m
Unit unit = Unit.MilliMeter;

Console.WriteLine("Result is "+(value*factors[(int)unit]));

enum Unit {
  Meter,
  CentiMeter,
  MilliMeter,
  Inches,
  Size,
}
