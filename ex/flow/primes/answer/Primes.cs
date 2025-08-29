int last = 1000000;
int max = -1;

// start at 2, the first prime number
for (int i=2 ; i<last ; i++) {
  bool isPrime = true;
  
  // skip even numbers greater than 2
  if (i>2 && (i&1) == 0)
    continue;
  
  // only check up to the square root of i
  for (int j=3 ; j*j<=i ; j+=2) {
    if (i%j == 0) {
      isPrime = false;
      break;
    }
  }
  
  if (isPrime) {
    // Console.WriteLine(i);
    max = i;
  }
}

Console.WriteLine("Highest prime is " + max);
