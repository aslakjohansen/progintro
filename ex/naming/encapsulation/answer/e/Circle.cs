class Circle {
  private double x, y;
  private double d;
  
  public Circle (double x, double y, double radius)
  {
    this.x = x;
    this.y = y;
    this.d = radius * 2;
  }
  
  public double GetX () {
    return x;
  }
  public void SetX (double x) {
    this.x = x;
  }
  
  public double GetY () {
    return y;
  }
  public void SetY (double y) {
    this.y = y;
  }
  
  public double GetD () {
    return d;
  }
  public void SetD (double d) {
    this.d = d;
  }
}
