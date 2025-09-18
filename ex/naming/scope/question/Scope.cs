class Scope {
  // location 0
  bonus = 42;
  // location 1
  
  static int Doubler (int value) {
    // location 2
    d = value * 2;
    // location 3
    return d;
    // location 4
  }
  
  // location 5
  
  public static void Main (string[] args) {
    // location 6
    sum = 0;
    // location 7
    for (/* location 8 */ i=0; /* location 9 */ i<100 ; /* location 10 */ i++) {
      // location 11
      tmp = Doubler(i);
      // location 12
      sum += tmp;
      // location 13
    }
    // location 14
    Console.WriteLine(sum + bonus);
    // location 15
  }
  
  // location 16
}
