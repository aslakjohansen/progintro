public class Months
{
  static string[] months = {
    "Januar",
    "Februar",
    "Marts",
    "April",
    "Maj",
    "Juni",
    "Juli",
    "August",
    "September",
    "Oktober",
    "November",
    "December",
  };
  
  static bool Write (string filename) {
    try {
      using (StreamWriter writer = new StreamWriter(filename)) {
        for (int i=0 ; i<months.Length ; i++) {
          writer.WriteLine((i + 1) + ":" + months[i]);
        }
      }
      
      return true;
    } catch (IOException) {
      return false;
    }
  }
  
  public static void Main (string[] args) {
    bool success = Write("output.txt");
    Console.WriteLine("Operation was" + (success ? " " : " not ") + "successful");
  }
}
