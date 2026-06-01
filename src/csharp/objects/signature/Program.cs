double d1 = 1.0;
double d2 = 3.0;
int i1 = 1;
int i2 = 0;
int i3 = -3;
Console.WriteLine(Helpers.max(d1, d2));
Console.WriteLine(Helpers.max(i1, i2));
Console.WriteLine(Helpers.max(i1, i2, i3));

class Helpers {
  // signature: max * (double, double)
  public static double max (double num1, double num2) {
    return (num1 > num2 ? num1 : num2);
  }
  
  // signature: max * (int, int)
  public static int max (int num1, int num2) {
    return (num1 > num2 ? num1 : num2);
  }
  
  // signature: max * (int, int, int)
  public static int max (int num1, int num2, int num3) {
    return max((num1 > num2 ? num1 : num2), num3);
  }
}

