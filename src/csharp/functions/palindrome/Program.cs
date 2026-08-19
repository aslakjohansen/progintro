char[][] inputs = {
  new char[] {'c', 'a', 'n', 'o', 'e'},
  new char[] {'k', 'a', 'y', 'a', 'k'},
};

bool is_palindrome(char[] input) {
  bool stepper(char[] input, int left, int right) {
    if (left>=right) return true;
    if (input[left]!=input[right]) return false;
    return stepper(input, left+1, right-1);
  }
  
  return stepper(input, 0, input.Length-1);
}

foreach (char[] input in inputs) {
  Console.WriteLine(is_palindrome(input));
}
