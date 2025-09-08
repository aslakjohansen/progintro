string[] days = {
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday",
  "Sunday"
};
string[] months = {
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December"
};
int[] monthsNormal = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
int[] monthsLeap = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

int year = 2019;
int firstDay = 1; // index for days

// find the correct month lengths
bool leap = (year%4==0 && year%100!=0) || (year%400==0);
int[] monthLengths = leap ? monthsLeap : monthsNormal;

// build base data structure
string[][] calendar = new string[12][];
int dayNumber = firstDay;
for (int month=0 ; month<calendar.Length ; month++) {
  int monthLength = monthLengths[month];
  calendar[month] = new string[monthLength];
  for (int day=0 ; day<monthLength ; day++) {
    calendar[month][day] = days[dayNumber++ % days.Length];
  }
}

for (int month=0 ; month<calendar.Length ; month++) {
  for (int day=0 ; day<calendar[month].Length ; day++) {
    string monthName = months[month];
    string dayName = calendar[month][day];
    
    Console.Write(year + " " + (day+1) + ". ");
    Console.WriteLine(monthName+": "+dayName);
  }
}
