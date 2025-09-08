int[] months = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
int month = 6;

if (month < 1 || month > 12) {
  Console.WriteLine("Error: The month \""+month+"\" is not within [1,12]");
} else {
  Console.WriteLine(months[month-1]);
}
