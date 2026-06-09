int[] monthsNormal = [31,28,31,30,31,30,31,31,30,31,30,31];
int[] monthsLeap   = [31,29,31,30,31,30,31,31,30,31,30,31];

for (int i=0 ; i<2030 ; i++) {
  int[] months = (i%4==0 ? monthsLeap : monthsNormal);
  Console.WriteLine("In year "+i+", February is "+months[1]+" days long");
}
