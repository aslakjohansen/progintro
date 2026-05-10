void fun () {
  throw new Exception("Oops!");
}

try {
  fun();
} catch (Exception e) {
  Console.WriteLine(e);
}
Console.WriteLine("But still alive ...");
