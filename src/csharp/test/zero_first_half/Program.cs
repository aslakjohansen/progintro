void zero_first_half (int[] data) {
  for (int i=0 ; i<data.Length/2 ; i++) {
    data[i] = 0;
  }
}

void print_array (int[] array) {
  foreach (int number in array) Console.Write(" "+number);
  Console.WriteLine("");
}

int[][] test_cases = [
  [1,2,3,4,5,6,7,8],
  [1,2,3,4,5,6,7]
];

foreach (int[] test_case in test_cases) {
  zero_first_half(test_case);
  print_array(test_case);
}
