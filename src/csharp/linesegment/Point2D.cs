class Point2D : Point<Point2D> {
  private double x, y;
  
  public Point2D (double x, double y) {
    this.x = x;
    this.y = y;
  }
  
  public override double DistanceTo (Point2D other) {
    double xdiff = this.x-other.x;
    double ydiff = this.y-other.y;
    return Math.Sqrt(xdiff*xdiff + ydiff*ydiff);
  }
}
