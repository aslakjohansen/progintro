public class Matrix
{
  public int Width; // number of columns (n)
  public int Height; // number of rows (m)
  public double[,] Values;
  
  public Matrix(double[,] values) {
    Height = values.GetLength(0);
    Width  = values.GetLength(1);
    Values = values;
  }
  
  public static Matrix Zeroes(int width, int height) {
    double[,] values = new double[height, width];
    for (int i = 0; i < height; i++)
      for (int j = 0; j < width; j++)
        values[i, j] = 0;
    return new Matrix(values);
  }
  
  public static Matrix Ones(int width, int height) {
    double[,] values = new double[height, width];
    for (int i = 0; i < height; i++)
      for (int j = 0; j < width; j++)
        values[i, j] = 1;
    return new Matrix(values);
  }
  
  public double[] GetRow(int index) {
    double[] row = new double[Width];
    for (int j = 0; j < Width; j++)
      row[j] = Values[index, j];
    return row;
  }
  
  public double[] GetColumn(int index) {
    double[] column = new double[Height];
    for (int i = 0; i < Height; i++)
      column[i] = Values[i, index];
    return column;
  }
  
  public override string ToString() {
    string toPrint = "";
    for (int i = 0; i < Height; i++)
    {
      for (int j = 0; j < Width; j++)
        toPrint += Values[i, j] + ", ";
      toPrint += "\n";
    }
    return toPrint;
  }
  public static bool operator +(bool m1, Matrix m2) {return true;}
  public static Matrix operator +(Matrix m1, Matrix m2) {
    if (m1.Width != m2.Width || m1.Height != m2.Height)
      throw new Exception("Parameters do not agree in size");
    
    double[,] result = new double[m1.Height,m1.Width];
    
    for (int i = 0; i < m1.Height; i++)
      for (int j = 0; j < m1.Width; j++)
        result[i, j] = m1.Values[i, j] + m2.Values[i, j];
    return new Matrix(result);
  }
  
  public static Matrix operator *(Matrix m1, Matrix m2) {
    if (m1.Width != m2.Height)
      throw new Exception("Incompatible parameter sizes");
    
    double[,] result = new double[m1.Height,m2.Width];
    
    for (int i = 0; i < m1.Height; i++)
      for (int j = 0; j < m2.Width; j++)
        result[i, j] = Dot(m1.GetRow(i), m2.GetColumn(j));
    
    return new Matrix(result);
  }
  
  private static double Dot(double[] row, double[] column) {
    double sum = 0;
    for (int k = 0; k < row.Length; k++)
      sum += row[k] * column[k];
    return sum;
  }
}
