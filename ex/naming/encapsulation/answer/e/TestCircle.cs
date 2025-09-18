public class TestCircle {
  public static void Main (string[] args) {
    Circle c = new Circle(1.24, 2.83, 12.7);
    Console.WriteLine("x=" + c.GetX() + " y=" + c.GetY() + " d=" + c.GetD());
    c.SetD(c.GetD() * 1.37);
    c.SetX(c.GetX() + 0.65);
    Console.WriteLine("x=" + c.GetX() + " y=" + c.GetY() + " d=" + c.GetD());
  }
}
