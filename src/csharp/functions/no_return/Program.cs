void print_array (int[] array) {
  Console.Write("[");
  foreach (int element in array) Console.Write(" "+element);
  Console.WriteLine(" ]");
}

int[] numbers = new int[] {3, 2, 6 -1, 7, 4, -6, -3, 9};
print_array(numbers);
