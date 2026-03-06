class LineSegment<T> where T :Point<T> {
  private T endpointA;
  private T endpointB;
  
  public LineSegment (T endpointA, T endpointB) {
    this.endpointA = endpointA;
    this.endpointB = endpointB;
  }
  
  public double GetLength () {
    return endpointA.DistanceTo(endpointB);
  }
}
