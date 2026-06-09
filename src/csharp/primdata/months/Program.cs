int[] months = new int[] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

months[1] = 42;
months[3] = months[1];

foreach (int i in months) {
  Console.WriteLine(i);
}
