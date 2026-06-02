int fib (int n) {
  switch (n) {
    case 0:
      return 0;
    case 1:
      return n;
    default:
      return fib(n-1)+fib(n-2);
  }
}

for (int n=0 ; n<10 ; n++)
  Console.WriteLine("fib("+n+") = "+fib(n));
