class DateTest {
  static void Main(string[] args) {
    for (long elapsed=1000 ; elapsed<=1000000 ; elapsed*=10) {
      DateTime d = System.DateTimeOffset.FromUnixTimeMilliseconds(elapsed).DateTime;
      Console.WriteLine(d.ToString());
    }
  }
}
