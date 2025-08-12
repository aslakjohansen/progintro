double c = -5;

while (c <= 40) {
  double f = c*9/5 + 32;
  
  Console.WriteLine("{0,5:F1}°C {1,5:F1}°F", c, f);
  
  c += 0.5;
}
