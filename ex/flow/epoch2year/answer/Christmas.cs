const int secsPerDay = 24 * 60 * 60;
const int secsPerYear = 365 * secsPerDay;

long epoch = (11 * 30 + 23) * 24 * 60 * 60;

long years = epoch / secsPerYear;
long days = (epoch - years * secsPerYear) / secsPerDay;
long month = days / 30;
long day = days % 30;

if (month == 11 && day == 23) {
  Console.WriteLine("It is Christmas!");
}
