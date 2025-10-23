public class Shell
{
  public static void Main (string[] args) {
    bool done = false;
    
    while (!done) {
      Console.Write("$ ");
      
      string? line = Console.ReadLine();
      if (line==null) continue;
      string[] commandArgs = line.Split(' ');
      string command = commandArgs[0];
      
      switch (command) {
        case "exit":
          done = true;
          break;
        case "echo":
          Console.WriteLine(line);
          break;
        case "time":
          Console.WriteLine(DateTime.Now);
          break;
        default:
          Console.WriteLine("Sorry, I don't quite know what to do with '"+line+"' :-(");
          break;
      }
    }
  }
}
