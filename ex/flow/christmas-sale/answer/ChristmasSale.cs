const int secsPerDay = 24 * 60 * 60;
const int secsPerYear = 360 * secsPerDay;
const int xmas = (11 * 30 + 23) * 24 * 60 * 60;

// long epoch = xmas - secsPerDay;
// long epoch = xmas + secsPerDay;
long epoch = xmas;

long years = epoch / secsPerYear;
long days = (epoch - years * secsPerYear) / secsPerDay;
long month = days / 30;
long day = days % 30;

double price = 599.95 * (month == 11 && day == 23 ? 0.7 : 1.0);

Console.WriteLine(price);
