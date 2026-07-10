int x = 1;
int y = 1;

for ( ; y<=10 ; y++) {
  for ( x = 1; x<=y ; x++) {
    if (x*y==27) {
      goto done;
    }
  }
}

done:
  Console.WriteLine(x+"*"+y+" = "+x*y);
