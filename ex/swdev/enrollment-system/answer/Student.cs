public class Student {
  public string name;
  public int    id;
  
  public Student (string nameValue, int idValue) {
    name = nameValue;
    id   = idValue;
  }
  
  public string GetName () {
    return name;
  }
}
