public class Highscores
{
  private int count;
  private string filename;
  private string[] players;
  private int[] scores;
  
  public Highscores (string filename, int count) {
    this.count = count;
    this.filename = filename;
    this.players = new string[count];
    this.scores = new int[count];
  }
  
  public bool Save () {
    try {
      StreamWriter writer = new StreamWriter(filename);
      
      for (int i = 0; i < count; i++) {
        if (players[i] != null) {
          writer.WriteLine(scores[i] + "," + players[i]);
        }
      }
      
      writer.Close();
      return true;
    }
    catch (IOException) {
      return false;
    }
  }
  
  public bool Load () {
    try {
      StreamReader reader = new StreamReader(filename);
      
      int i = 0;
      while (!reader.EndOfStream) {
        // guard: filled up all spaces
        if (i >= count) break;
        
        string? line = reader.ReadLine();
        if (line==null) throw new Exception("Parse error!");
        string[] pair = line.Split(',');
        
        // guard: length of pair
        if (pair.Length != 2) {
          Console.WriteLine("Too many elements in line: " + line);
          return false;
        }
        
        // read score
        try {
          scores[i] = int.Parse(pair[0]);
        } catch (Exception) {
          Console.WriteLine("Unable to parse index: " + pair[0]);
          return false;
        }
        
        // read player
        players[i] = pair[1];
        
        i++;
      }
      
      reader.Close();
      return true;
    } catch (FileNotFoundException) {
      return false;
    }
  }
  
  public bool NewScore (int score, string player) {
    int i;
    
    // locate correct place
    for (i=0 ; i<count&&scores[i]>score ; i++) { }
    
    // guard: not a top score
    if (i == count) return false;
    
    // make space
    for (int j=count-2 ; j>=i ; j--) {
      scores[j + 1] = scores[j];
      players[j + 1] = players[j];
    }
    
    // insert
    scores[i] = score;
    players[i] = player;
    
    return true;
  }
  
  public bool ValidIndex (int i) {
    return i >= 0 && i < count && players[i] != null;
  }
  
  public int GetScore (int i) {
    if (!ValidIndex(i)) return -1;
    
    return scores[i];
  }
  
  public string GetPlayer (int i) {
    if (!ValidIndex(i)) throw new Exception("Unknown player "+ i);
    
    return players[i];
  }
  
  public static void Main (string[] args) {
    Highscores hs = new Highscores("highscores.csv", 10);
    hs.Load();
    
    if (hs.ValidIndex(0)) {
      hs.NewScore(hs.GetScore(0) - 1, hs.GetPlayer(0) + "-");
      hs.NewScore(hs.GetScore(0) + 1, hs.GetPlayer(0) + "+");
    } else {
      hs.NewScore(42, "Marvin");
    }
    
    hs.Save();
  }
}
