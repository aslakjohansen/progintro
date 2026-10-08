class Program {
  public static void Main (string[] args) {
    for (int i=0 ; i<args.Length ; i++) {
      Console.WriteLine("Arg #" + i + ": " + args[i]);
    }
  }
}
