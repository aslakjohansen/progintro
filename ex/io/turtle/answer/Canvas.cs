public class Canvas
{
  int width;
  int height;
  bool[][] data;
  
  public Canvas (int width, int height) {
    this.width = width;
    this.height = height;
    this.data = new bool[height][];
    for (int i=0 ; i<height ; i++) {
      this.data[i] = new bool[width];
    }
  }
  
  public bool GetValue (int x, int y) {
    return data[y][x];
  }
  
  public void SetValue (int x, int y, bool v) {
    data[y][x] = v;
  }
  
  public void Print () {
    Console.Write("+");
    for (int x=0 ; x<width ; x++) Console.Write("-");
    Console.WriteLine("+");
    
    for (int y=0 ; y<height ; y++) {
      Console.Write("|");
      for (int x=0 ; x<width ; x++)
        Console.Write((GetValue(x, y) ? "X" : " "));
      Console.WriteLine("|");
    }
    
    Console.Write("+");
    for (int x=0 ; x<width ; x++) Console.Write("-");
    Console.WriteLine("+");
  }
}
