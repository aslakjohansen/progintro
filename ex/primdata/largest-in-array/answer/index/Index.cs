int[] a = {1, 7, 4, 1, 23, 54, 8, 34, 54, 12, 11, 8, 25};

int max  = a[0];
int maxi = 0;

for (int i=0 ; i<a.Length ; i++) {
  int value = a[i];
  if (value > max) {
    max  = value;
    maxi = i;
  }
}

Console.WriteLine(maxi);
