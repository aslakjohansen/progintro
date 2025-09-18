public class Circle {
  private Coordinate c;
  private double d;
  
  public Circle (double x, double y, double radius)
  {
    this.c = new Coordinate(x, y);
    this.d = radius * 2;
  }
  
  public double GetX () {
    return c.GetX();
  }
  public void SetX (double x) {
    c.SetX(x);
  }
  
  public double GetY () {
    return c.GetY();
  }
  public void SetY (double y) {
    c.SetY(y);
  }
  
  public double GetD () {
    return d;
  }
  public void SetD (double d) {
    this.d = d;
  }
}
