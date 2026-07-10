uint i = 0;
loop:
  if (i<10) {
    Console.WriteLine(i);
    i++;
    goto loop;
  }
