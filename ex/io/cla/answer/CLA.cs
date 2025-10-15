public class CLA
{
  public static void Main (string[] args) {
    // guard: command line arguments
    if (args.Length != 2) {
      Console.WriteLine("Syntax: dotnet run FIRST_INTEGER SECOND_INTEGER");
      Console.WriteLine("        dotnet run 42 56");
      return;
    }
    
    try {
      int a = int.Parse(args[0]);
      int b = int.Parse(args[1]);
      
      Console.WriteLine(a + b);
    } catch (FormatException e) {
      Console.WriteLine("Eww, that's nasty!\n" + e.Message);
    }
  }
}
