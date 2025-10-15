class Person
{
  private string Name { get; set; }
  private int    Age { get; set; }
  private string Cpr { get; set; }
  
  public Person (string name, int age, string cpr) {
    this.Name = name;
    this.Age  = age;
    this.Cpr  = cpr;
  }
  
  public override string ToString () {
    return "[Person name='"+Name+"' age='"+Age+"' cpr='"+Cpr+"']";
  }
  
  public static void Main (string[] args) {
    // subexercise 2
    List<Person> ps = new List<Person>();
    ps.Add(new Person("Emma" , 1, "010101-0101"));
    ps.Add(new Person("Ella" , 2, "020202-0202"));
    ps.Add(new Person("Ida"  , 3, "030303-0303"));
    ps.Add(new Person("Mynte", 4, "040404-0404"));
    ps.Add(new Person("Tinka", 5, "050505-0505"));
    
    // subexercise 3
    foreach (Person p in ps) {
      if (p.Cpr == "010101-0101") {
        Console.WriteLine(p);
      }
    }
    
    // subexercise 4
    Dictionary<string, Person> reg = new Dictionary<string, Person>();
    foreach (Person p in ps) {
      reg.Add(p.Cpr, p);
    }
    
    // subexercise 5
    Console.WriteLine(reg["010101-0101"]);
  }
}
