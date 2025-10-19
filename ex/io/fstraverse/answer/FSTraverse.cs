public class FSTraverse
{
  static void Traverse (List<string> result, DirectoryInfo directory, string extension) {
    foreach (FileInfo file in directory.GetFiles()) {
      if (file.Extension == extension) {
        result.Add(file.FullName);
      }
    }
    
    foreach (DirectoryInfo subDirectory in directory.GetDirectories()) {
      Traverse(result, subDirectory, extension);
    }
  }
  
  public static void Main (string[] args) {
    // guard: command line arguments
    if (args.Length != 1) {
      Console.WriteLine("Syntax: dotnet run PATH");
      Console.WriteLine("        dotnet run .");
      return;
    }
    
    string path = args[0];
    
    Console.WriteLine("Searching "+path);
    List<string> matches = new List<string>();
    Traverse(matches, new DirectoryInfo(path), ".csv");
    
    Console.WriteLine("Matches:");
    foreach (string match in matches) {
      Console.WriteLine(" - " + match);
    }
  }
}
