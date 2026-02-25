class Point2D : Point<Point2D> {
  private double x, y;
  
  public Point2D (double x, double y) {
    this.x = x;
    this.y = y;
  }
  
  // public double DistanceTo (Point<Point2D> other) {
  // Point2D point = (Point2D) other; // TODO: how to avoid this cast?
    public double DistanceTo (Point2D point) {
    // Point2D point = (Point2D) other; // TODO: how to avoid this cast?
    double xdiff = this.x-point.x;
    double ydiff = this.y-point.y;
    return Math.Sqrt(xdiff*xdiff + ydiff*ydiff);
  }
}
