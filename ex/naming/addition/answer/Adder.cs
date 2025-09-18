class Adder
{
  static string Solve (int a, int b) {
    return a+" + "+b+" = "+(a+b);
  }
  
  static string Solve (double a, double b) {
    return a+" + "+b+" = "+(a+b);
  }
  
  public static void Main (string[] args) {
    Console.WriteLine(Solve(3, 5));
    Console.WriteLine(Solve(3.14, 5.12));
  }
}
