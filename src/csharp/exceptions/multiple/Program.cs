int dummy;
int[]? array;

for (int i=0 ; i<5 ; i++) {
  try {
    switch (i) {
    case 0:
      array = new int[0];
      dummy = array[1];
      break;
    case 1:
      array = null;
      dummy = array[0];
      break;
    case 2:
      dummy = 1/(i-i); // note the hack to have the compiler allow the /0
      break;
    case 3:
      throw new Exception("Oops!");
    }
    Console.WriteLine("No problem!");
  } catch (IndexOutOfRangeException) {
    Console.WriteLine("Caught IndexOutOfRangeException");
  } catch (NullReferenceException) {
    Console.WriteLine("Caught NullReferenceException");
  } catch (DivideByZeroException) {
    Console.WriteLine("Caught DivideByZeroException");
  } catch (Exception) {
    Console.WriteLine("Caught Exception");
  }
}
