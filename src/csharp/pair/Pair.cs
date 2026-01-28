class Pair<T> {
  public T a;
  public T b;
  
  public Pair (T a, T b) {
    this.a = a;
    this.b = b;
  }
  
  public override string ToString () {
    return "("+a+","+b+")";
  }
}
