class IntPair {
  public int a;
  public int b;
  
  public IntPair (int a, int b) {
    this.a = a;
    this.b = b;
  }
  
  public override string ToString () {
    return "("+a+","+b+")";
  }
}
