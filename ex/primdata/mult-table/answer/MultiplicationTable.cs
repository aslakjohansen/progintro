const int multiplier = 3;
const int count = 10;

// allocate memory
int[] data = new int[count];

// populate array
for (int i=0 ; i<data.Length ; i++) {
  data[i] = i*multiplier;
}

// perform test
int test1 = 0;
int test2 = count - 1;
Console.WriteLine(test1+" * "+multiplier+" = "+data[test1]);
Console.WriteLine(test2+" * "+multiplier+" = "+data[test2]);
