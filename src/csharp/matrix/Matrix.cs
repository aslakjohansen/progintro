public class Matrix
{
  public int       Width;  // number of columns
  public int       Height; // number of rows
  public double[,] Values;
  
  public Matrix (double[,] values) {
    Height = values.GetLength(0);
    Width  = values.GetLength(1);
    Values = values;
  }
  
  public static Matrix Constant (int width, int height, double val) {
    double[,] values = new double[height, width];
    for (int i=0 ; i<height ; i++)
      for (int j=0 ; j<width ; j++)
        values[i, j] = val;
    return new Matrix(values);
  }
  
  public static Matrix Zeroes (int width, int height) { return Constant(width, height, 0); }
  public static Matrix Ones   (int width, int height) { return Constant(width, height, 1); }
  
  public static Matrix Identity (int size) {
    double[,] values = new double[size, size];
    for (int i=0 ; i<size ; i++)
      values[i, i] = 1;
    return new Matrix(values);
  }
  
  public override string ToString () {
    string result = "";
    for (int i=0 ; i<Height ; i++) {
      for (int j=0 ; j<Width ; j++)
        result += (j==0 ? "" : ", ") + Values[i, j];
      result += "\n";
    }
    return result;
  }
  
  public static Matrix operator + (Matrix m1, Matrix m2) {
    if (m1.Width != m2.Width || m1.Height != m2.Height)
      throw new Exception("Parameters do not agree in size");
    
    double[,] result = new double[m1.Height, m1.Width];
    
    for (int i=0 ; i<m1.Height ; i++)
      for (int j=0 ; j<m1.Width ; j++)
        result[i, j] = m1.Values[i, j] + m2.Values[i, j];
    return new Matrix(result);
  }
  
  public static Matrix operator * (Matrix m1, Matrix m2) {
    if (m1.Width != m2.Height)
      throw new Exception("Incompatible parameter sizes");
    
    double[,] result = new double[m1.Height, m2.Width];
    
    for (int i=0 ; i<m1.Height ; i++)
      for (int j=0 ; j<m2.Width ; j++)
        for (int k=0 ; k<m1.Width ; k++ )
          result[i, j] += m1.Values[i,k] * m2.Values[k,j];
    return new Matrix(result);
  }
}
