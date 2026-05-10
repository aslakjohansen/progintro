try {
  throw new Exception("Oops!");
} catch (Exception e) {
  Console.WriteLine(e);
}
Console.WriteLine("But still alive ...");
