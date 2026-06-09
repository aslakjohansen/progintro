int[] months = new int[] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

double total = 0;
foreach (int length in months) {
  total += length;
}

Console.WriteLine("Average month length is "+total/months.Length);
