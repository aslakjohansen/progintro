int[] monthsNormal = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
int[] monthsLeap   = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

for (int year=2000 ; year<=2020 ; year++) {
  bool leap = (year%4==0 && year%100!=0) || (year%400==0);
  int[] month = leap ? monthsLeap : monthsNormal;
  
  Console.Write(year + ": [ ");
  foreach (int length in month) {
    Console.Write(length + " ");
  }
  Console.WriteLine("]");
}
