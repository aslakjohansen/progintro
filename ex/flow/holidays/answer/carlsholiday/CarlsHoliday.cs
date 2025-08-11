const int JANUARY = 0;
const int FEBRUARY = 1;
const int MARCH = 2;
const int APRIL = 3;
const int MAY = 4;
const int JUNE = 5;
const int JULY = 6;
const int AUGUST = 7;
const int SEPTEMBER = 8;
const int OCTOBER = 9;
const int NOVEMBER = 10;
const int DECEMBER = 11;

// choose a test case
int month = OCTOBER;
// int month = NOVEMBER;

string message = (month == OCTOBER ? "Autumn Holiday"
               : (month == DECEMBER ? "Christmas Holiday"
               : (month == APRIL ? "Spring Holiday"
               : (month == JULY || month == AUGUST ? "Summer Holiday"
               : "Hard work"))));
Console.WriteLine(message);
