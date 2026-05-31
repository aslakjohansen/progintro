int area (int w, int h) {
  return w * h;
}

for (int h=1 ; h<11 ; h++) {
  for (int w=1 ; w<11 ; w++)
    Console.Write(" {0,3}", area(w,h));
  Console.WriteLine("");
}
