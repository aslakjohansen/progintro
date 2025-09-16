Matrix m1 = Matrix.Ones(2, 3);
Matrix m2 = new Matrix(new double[,] {
  {1, 2, 3, 4},
  {5, 6, 7, 8}
});
Matrix m3 = Matrix.Zeroes(4,3);
Console.WriteLine(m1*m2+m3);
Console.WriteLine(false + m3);
