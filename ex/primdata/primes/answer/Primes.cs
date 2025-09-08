int last = 1000000;
bool[] sieve = new bool[last];

// initialize sieve
for (int i=1 ; i<sieve.Length ; i++)
  sieve[i] = true;

// fill out sieve
for (int i=2 ; i<Math.Sqrt(sieve.Length) ; i++) {
  if (sieve[i]) {
    for (int j=i*2 ; j<last ; j+=i) {
      sieve[j] = false;
    }
  }
}

// find and print out largest prime
int max = -1;
for (int i=last-1 ; i>0 ; i--) {
  if (sieve[i]) {
    max = i;
    break;
  }
}
Console.WriteLine("Highest prime is "+max);
