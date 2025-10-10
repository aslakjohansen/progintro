int month = 6;
int length = -1;

length = (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 ||
          month == 10 || month == 12 ? 31 : 0)
       + (month == 2 ? 28 : 0)
       + (month == 4 || month == 6 || month == 9 || month == 11 ? 30 : 0);

if (length == -1) {
  Console.WriteLine("Error: Month \"" + month + "\" is outside of [1,12]");
} else {
  Console.WriteLine(length);
}
