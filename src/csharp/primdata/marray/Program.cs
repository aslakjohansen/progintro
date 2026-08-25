int[,] marray = {
  {1,2,3,4},
  {2,3,4,5},
  {3,4,5,6}
};

for (int y=0 ; y<marray.GetLength(0) ; y++) {
  for (int x=0 ; x<marray.GetLength(1) ; x++)
    Console.Write(marray[y,x]+" ");
  Console.WriteLine("");
}
