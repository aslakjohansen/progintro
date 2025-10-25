class RandomTest {
  const int ITERATIONS = 10;
  const int LENGTH     = 48;
  
  static Random r = new Random();
  
  static int[] Init (int length) {
    int[] a = new int[length];
    for (int i=0 ; i<a.Length ; i++) {
      a[i] = r.Next() % 100;
    }
    return a;
  }
  
  static int[]? Diff (int[] a, int[] b) {
    // guard: uneven length of inputs
    if (a.Length!=b.Length) return null;
    
    int[] d = new int[a.Length];
    for (int i=0 ; i<d.Length ; i++) {
      d[i] = b[i] - a[1];
    }
    return d;
  }
  
  static void Print (int[]? a) {
    // guard
    if (a==null) {
      Console.WriteLine("NULL");
      return;
    }
    
    int sum = 0;
    Console.Write("[");
    for (int i=0 ; i<a.Length ; i++) {
      // break line nicely
      if (i!=0 && i%24==0) {
        Console.WriteLine("");
        Console.Write(" ");
      }
      
      Console.Write("{0,5}", a[i]);
      sum += a[i];
    }
    int mean = sum/a.Length;
    
    double vsum = 0;
    for (int i=0 ; i<a.Length ; i++) {
      double diff = a[i]-mean;
      vsum += diff*diff;
    }
    
    Console.Write(" ] avg={0,4} stdev={1,5:0.00}", mean, Math.Sqrt(vsum/a.Length));
    Console.WriteLine("");
  }
  
  public static void Main (string[] args) {
    for (int i=0 ; i<ITERATIONS ; i++) {
      int[] a1 = Init(LENGTH);
      int[] a2 = Init(LENGTH);
      int[]? ad = Diff(a1, a2);
      Print(ad);
    }
  }
}
