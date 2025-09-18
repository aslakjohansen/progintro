class TestCircle {
  static void Main (string[] args) {
    Circle c = new Circle(1.24, 2.83, 12.7);
    Console.WriteLine("x=" + c.x + " y=" + c.y + " r=" + c.r);
    c.r *= 1.37;
    c.x += 0.65;
    Console.WriteLine("x=" + c.x + " y=" + c.y + " r=" + c.r);
  }
}
