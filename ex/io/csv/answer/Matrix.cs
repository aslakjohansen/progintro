public class Matrix
{
  double[][] Data { get; set; }
  
  public Matrix (string filename) {
    Data = new double[0][]; // to fool the compiler into not giving us a wrong warning
    bool success = Load(filename);
    if (!success) {
      Console.WriteLine("Oops, this is not gonna be pretty!");
      throw new Exception("Unable to load "+filename);
    }
  }
  
  public Matrix (int x, int y) {
    Data = new double[y][];
    for (int i=0; i<y ; i++) {
      Data[i] = new double[x];
    }
  }
  
  public int GetHeight () {
    return Data.Length;
  }
  
  public int GetWidth () {
    return Data[0].Length;
  }
  
  public bool Save (string filename) {
    try {
      StreamWriter writer = new StreamWriter(filename);
      
      foreach (double[] row in Data) {
        for (int i=0 ; i<row.Length ; i++) {
          double cell = row[i];
          writer.Write((i == 0 ? "" : ",") + cell);
        }
        writer.WriteLine();
      }
      
      writer.Close();
      return true;
    } catch (IOException) {
      return false;
    }
  }
  
  private bool Load (string filename) {
    try {
      List<string> lines = new List<string>();
      
      // read file
      StreamReader reader = new StreamReader(filename);
      {
        string? line;
        while ((line = reader.ReadLine()) != null) {
          lines.Add(line);
        }
      }
      reader.Close();
      
      // parse contents of file
      int x = 0;
      int y = 0;
      try {
        Data = new double[lines.Count][];
        for (y=0 ; y<lines.Count ; y++) {
          string line = lines[y];
          string[] cells = line.Split(',');
          Data[y] = new double[cells.Length];
          for (x=0 ; x<cells.Length ; x++) {
            Data[y][x] = double.Parse(cells[x]);
          }
        }
      } catch (FormatException) {
        Console.WriteLine("Unable to parse x=" + x + " y=" + y);
        return false;
      }
    } catch (FileNotFoundException) {
      return false;
    }
    
    return true;
  }
  
  public static void Main (string[] args) {
    string m1_filename = "m1.csv";
    string m2_filename = "m2.csv";
    
    Matrix m1 = new Matrix(4, 6);
    m1.Save(m1_filename);
    
    Matrix m2 = new Matrix(m1_filename);
    for (int i=0 ; i<Math.Min(m2.GetHeight(), m2.GetWidth()) ; i++) {
      m2.Data[i][i] += 1;
    }
    m2.Save(m2_filename);
  }
}
