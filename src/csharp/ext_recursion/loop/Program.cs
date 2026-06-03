uint fib (uint n) {
  switch (n) {
    case 0:
      return 0;
    case 1:
      return n;
    default:
      uint prev = 1;
      uint prevprev = 0;
      for (uint i=2 ; i<=n ; i++) {
        uint temp = prev;
        prev = prev + prevprev;
        prevprev = temp;
      }
      return prev;
  }
}

for (uint n=0 ; n<10 ; n++)
  Console.WriteLine("fib("+n+") = "+fib(n));
