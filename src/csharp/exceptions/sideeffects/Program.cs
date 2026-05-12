int[] input = new int[]{1,2,4,5};

int sum = 0;
int count = 0;

foreach (int i in input) {
  count++;
  try {
    if (i==4) throw new Exception("Imagine that something went wrong");
    sum += i;
  } catch (Exception) {}
}

Console.WriteLine("average: "+(sum/count));
