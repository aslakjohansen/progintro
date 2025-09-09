int Add (int a, int b) {
  return a + b;
}

for (int a=0 ; a<=10 ; a++) {
  for (int b=0 ; b<=10 ; b++) {
    Console.Write("{0,3}", Add(a, b));
  }
  Console.WriteLine();
}
