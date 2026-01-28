class PointPair {
  public Point a;
  public Point b;
  
  public PointPair (Point a, Point b) {
    this.a = a;
    this.b = b;
  }
  
  public override string ToString () {
    return "("+a+","+b+")";
  }
}
