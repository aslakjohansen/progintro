for (int y=1 ; y<=10 ; y++) {
  for (int x=1 ; x<=y ; x++) {
    Console.Write(string.Format("{0,4}", x*y));
  }
  Console.WriteLine("");
}
