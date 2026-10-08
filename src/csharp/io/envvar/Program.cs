using System.Collections;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine("The following environment variables are defined:");
    foreach (DictionaryEntry de in Environment.GetEnvironmentVariables()) {
      Console.WriteLine("- '"+de.Key+"': '"+de.Value+"'");
    }
  }
}
