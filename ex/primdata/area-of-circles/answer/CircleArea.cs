int[] radiuses = {1, 3, 5};
double pi = 3.14;

foreach (int r in radiuses) {
  Console.WriteLine("r=" + r + " -> area=" + (pi * r * r));
}
