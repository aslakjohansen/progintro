double square_root(double x) {
  double candidate = 0.0;
  
  for (double pointer = 1000000000.0 ; pointer > 0.000000001 ; pointer /= 10) {
    candidate += 10 * pointer;
    for (int i = 0 ; i < 10 ; i++) {
      candidate -= pointer;
      if (candidate * candidate < x) {
        break;
      }
    }
  }
  
  return candidate;
}

for (double x = 1; x <= 10; x++) {
  Console.WriteLine("sqrt(" + x + ")=" + square_root(x));
}
