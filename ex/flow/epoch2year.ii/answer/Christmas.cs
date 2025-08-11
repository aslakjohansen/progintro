const int secsPerDay = 24 * 60 * 60;
const int secsPerYear = 365 * secsPerDay;
const int xmas = (11 * 30 + 23) * 24 * 60 * 60;

long epoch = xmas + secsPerDay; // 1 day after xmas.

long years = epoch / secsPerYear;
long days = (epoch - years * secsPerYear) / secsPerDay;
long month = days / 30;
long day = days % 30;

if (month == 11 && day == 23) {
  Console.WriteLine("It is Christmas!");
} else {
  long daysLeft = (xmas + secsPerYear - epoch) % secsPerYear / secsPerDay;
  Console.WriteLine("It is Christmas in " + daysLeft + " days");
}
