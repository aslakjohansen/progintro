const double pi = 3.14;

double area (double r) {
  return pi * r * r;
}

double circumference (double r) {
  return 2 * pi * r;
}

for (double r = 1 ; r <= 5 ; r += 2) {
  Console.WriteLine("r="+r+" => area="+area(r)+" circ="+circumference(r));
}
