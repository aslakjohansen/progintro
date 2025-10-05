class Timing
{
  static double initialValue = 1.0000001;
  
  static double Fun (double x, double y) {
    if (y <= 1) {
      return x;
    } else {
      return Fun(x, y - 1) * Fun(x, y - 1);
    }
  }
  
  public static void Main (string[] args) {
    for (double i=1 ; i<=32 ; i++) {
      long t0 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      double f = Fun(initialValue, i);
      long t1 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      
      Console.WriteLine("fun(" + initialValue + "," + i + ") = " + f +
                        " (calculation took " + (t1 - t0) + "ms)");
    }
  }
}
