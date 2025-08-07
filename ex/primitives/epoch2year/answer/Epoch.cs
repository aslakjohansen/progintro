const int secsPerDay = 24 * 60 * 60;
const int secsPerYear = 365 * secsPerDay;

long epoch = 99023040;

long years = epoch / secsPerYear;
long days = (epoch - years * secsPerYear) / secsPerDay;

Console.WriteLine(epoch + " seconds -> " + years + " years and " + days + " days");
