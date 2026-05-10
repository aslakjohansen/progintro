for (int i=0 ; i<2 ; i++) {
  try {
    if (i==0) throw new Exception("Oops!");
    Console.WriteLine(i);
  } catch (Exception e) {
    Console.WriteLine(e);
  } finally {
    Console.WriteLine("Anyways ...");
  }
}
