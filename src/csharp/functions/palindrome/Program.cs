char[][] inputs = {
  new char[] {'a', 'b', 'c'},
  new char[] {'a', 'b', 'c', 'b', 'a'},
};

bool is_palindrome(char[] input, int left, int right) {
  if (left>=right) return true;
  if (input[left]!=input[right]) return false;
  return is_palindrome(input, left+1, right-1);
}

foreach (char[] input in inputs) {
  Console.WriteLine(is_palindrome(input, 0, input.Length-1));
}
