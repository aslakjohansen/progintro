int month = 6;
int length = -1;

if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 ||
    month == 10 || month == 12) {
  length = 31;
} else if (month == 2) {
  length = 28;
} else if (month == 4 || month == 6 || month == 9 || month == 11) {
  length = 30;
}

if (length == -1) {
  Console.WriteLine("Error: Month \"" + month + "\" is outside of [1,12]");
} else {
  Console.WriteLine(length);
}
