public class TestCircle {
  public static void Main (string[] args)
  {
     Circle c = new Circle(1.24, 2.83, 12.7);
     Console.WriteLine("X=" + c.x + " Y=" + c.y + " D=" + c.d);
     c.d *= 1.37;
     c.x += 0.65;
     Console.WriteLine("X=" + c.x + " Y=" + c.y + " D=" + c.d);
  }
}
