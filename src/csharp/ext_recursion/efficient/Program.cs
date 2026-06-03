uint fib (uint n) {
  uint fibrec (uint n, uint max, uint prev, uint prevprev) {
    uint result = prev + prevprev;
    if (n<max) {
      result = fibrec(n+1, max, result, prev);
    }
    return result;
  }
  
  switch (n) {
    case 0:
      return 0;
    case 1:
      return n;
    default:
      return fibrec(1, n, 0, 1);
  }
}

for (uint n=0 ; n<10 ; n++)
  Console.WriteLine("fib("+n+") = "+fib(n));
