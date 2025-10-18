public class Reverse
{
  static string ReverseString (string? input) {
    if (input==null) return "";
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }
  
  public static void Main (string[] args) {
    Console.Write("Please enter a text: ");
    string? line = Console.ReadLine();
    string reversed = ReverseString(line);
    Console.WriteLine(reversed);
  }
}
