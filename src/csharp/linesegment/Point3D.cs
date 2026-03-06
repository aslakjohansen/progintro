class Point3D : Point<Point3D> {
  private double x, y, z;
  
  public Point3D (double x, double y, double z) {
    this.x = x;
    this.y = y;
    this.z = z;
  }
  
  public override double DistanceTo (Point3D other) {
    double xdiff = this.x-other.x;
    double ydiff = this.y-other.y;
    double zdiff = this.z-other.z;
    return Math.Sqrt(xdiff*xdiff + ydiff*ydiff + zdiff*zdiff);
  }
}
