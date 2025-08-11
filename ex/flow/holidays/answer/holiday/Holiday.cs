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

switch (month)
{
    case OCTOBER:
        Console.WriteLine("Autumn Holiday");
        break;
    case DECEMBER:
        Console.WriteLine("Christmas Holiday");
        break;
    case APRIL:
        Console.WriteLine("Spring Holiday");
        break;
    case AUGUST:
        Console.WriteLine("Summer Holiday");
        break;
    default:
        Console.WriteLine("Hard work");
        break;
}
