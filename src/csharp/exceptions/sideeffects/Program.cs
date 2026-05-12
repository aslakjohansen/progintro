int[] input = new int[]{1,2,4,5};

int sum = 0;
int count = 0;

foreach (int i in input) {
  count++;
  try {
    if (i==2) throw new Exception("Imagine that something went wrong");
  } catch (Exception) {}
  sum += i;
}

Console.WriteLine("average: "+(sum/count));
