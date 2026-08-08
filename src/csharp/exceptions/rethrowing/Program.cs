try {
  throw new Exception("Oops!");
} catch (Exception) {
  Console.WriteLine("Things are about to go badly ...");
  throw; // implicit reference to caught exception
}
