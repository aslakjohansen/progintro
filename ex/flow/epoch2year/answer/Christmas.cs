const int secsPerDay = 24 * 60 * 60;
const int secsPerYear = 365 * secsPerDay;

// long epoch = 99023040;
long epoch = (11 * 30 + 23) * 24 * 60 * 60;

long years = epoch / secsPerYear;
long days = (epoch - years * secsPerYear) / secsPerDay;
long month = days / 30;
long day = days % 30;

// Console.WriteLine("" + (day + 1) + "/" + (month + 1));
if (month == 11 && day == 23)
{
    Console.WriteLine("Det er jul!");
}