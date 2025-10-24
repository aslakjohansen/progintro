class Score {
  public static void Main (string[] args) {
    int points = 0; // imagine an arbitrary number of points between 0 and 100
    
    Console.Write("You ");
    
    if (points >= 50) {
      Console.Write("PASSED");
    }
    
    if (points <= 50) {
      Console.Write("FAILED");
    }
    
    Console.WriteLine("!");
  }
}
