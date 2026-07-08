int sum = 0;

for (int i=1 ; i<100 ; i++) {
  if (i/7*7==i) continue;
  sum += i;
}

Console.WriteLine(sum);
