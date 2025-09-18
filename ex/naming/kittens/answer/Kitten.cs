class Kitten{
  double cuteness;
  
  static int count = 0;
  
  public Kitten (double cuteness) {
    this.cuteness = cuteness;
    if (cuteness > 9000) {
      Console.WriteLine("The cuteness of this kitten is over 9000!");
    }
    count++;
  }
  
  public static void Main (string[] args) {
    for (int i = 0; i < 9002; i++) {
      new Kitten(i);
    }
    Console.WriteLine("There are " + count + " kittens.");
  }
}
