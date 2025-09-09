double discriminant (double a, double b, double c) {
  return b * b - 4 * a * c;
}

int signum (double value) {
  if (value < 0) {
    return -1;
  } else if (value == 0) {
    return 0;
  } else {
    return 1;
  }
}

double[] calculate_roots (double a, double b, double c) {
  double d = discriminant(a, b, c);
  int rootCount = signum(d);
  double[] roots = null;
  
  switch (rootCount) {
    case -1:
      roots = new double[0];
      break;
    case 0:
      roots = new double[1];
      roots[0] = (-b) / (2 * a);
      break;
    case 1:
      roots = new double[2];
      roots[0] = (-b + Math.Sqrt(d)) / (2 * a);
      roots[1] = (-b - Math.Sqrt(d)) / (2 * a);
      break;
  }
  
  return roots;
}

double[][] tests = {
  new double[] { 1, -4, 1 },
  new double[] { 1, -4, 4 },
  new double[] { 1, -4, 10 },
};

foreach (double[] testcase in tests) {
  double a = testcase[0];
  double b = testcase[1];
  double c = testcase[2];
  
  double[] rs = calculate_roots(a, b, c);
  
  Console.WriteLine("y = "+a+"x² + "+b+"x + "+c+" has "+rs.Length+" roots:");
  for (int i = 0; i < rs.Length; i++) {
    Console.WriteLine(" - Root " + i + ": " + rs[i]);
  }
  Console.WriteLine("");
}
