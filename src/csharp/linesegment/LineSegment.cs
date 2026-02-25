class LineSegment<T> where T :Point<T> {
  private Point<T> endpointA;
  private Point<T> endpointB;
  
  public LineSegment (Point<T> endpointA, Point<T> endpointB) {
    this.endpointA = endpointA;
    this.endpointB = endpointB;
  }
  
  public double GetLength () {
    return endpointA.DistanceTo(endpointB);
  }
}
