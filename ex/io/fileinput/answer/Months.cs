public class Months
{
  static string[] months = new string[12];
  
  static bool Read (string filename) {
    try {
      StreamReader reader = new StreamReader(filename);
      
      string? line;
      while ((line = reader.ReadLine()) != null) {
        string[] pair = line.Split(':');
        int i;
        
        // guard: length of pair
        if (pair.Length != 2) {
          Console.WriteLine("Too many elements in line: " + line);
          continue;
        }
        
        try {
          i = int.Parse(pair[0]);
        } catch (Exception) {
          Console.WriteLine("Unable to parse index: " + pair[0]);
          continue;
        }
        
        // guard: index out of range
        if (i < 1 || i > 12) {
          Console.WriteLine("Month index out of range: " + i);
          continue;
        }
        
        months[i-1] = pair[1];
      }
      
      reader.Close();
      return true;
    } catch (FileNotFoundException) {
      return false;
    }
  }
  
  public static void Main (string[] args) {
    bool success = Read("output.txt");
    Console.WriteLine("Operation was" + (success ? " " : " not ") + "successful");
    
    Console.WriteLine("Month table:");
    for (int i=0 ; i<months.Length ; i++) {
      Console.WriteLine(" - "+(i + 1)+": "+months[i]);
    }
  }
}
