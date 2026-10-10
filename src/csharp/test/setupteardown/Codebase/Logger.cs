class Logger {
  string filename;
  
  public Logger (string filename) {
    this.filename = filename;
  }
  
  public void Append (string line) {
    System.IO.File.AppendAllText(filename, line);
  }
}
