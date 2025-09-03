int[] a = {1, 7, 4, 1, 23, 54, 8, 34, 54, 12, 11, 8, 25};

// find max
int max = a[0];
foreach (int value in a) {
  if (value > max) {
    max = value;
  }
}

// locate occurrences and output them
for (int i=0; i<a.Length ; i++) {
  int value = a[i];
  if (value==max) {
    Console.WriteLine(i);
  }
}
