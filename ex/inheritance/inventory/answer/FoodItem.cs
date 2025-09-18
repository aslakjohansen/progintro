class FoodItem : Item {
  private DateTime expiresAt;
  
  public FoodItem (string name, double price, DateTime expiresAtValue)
       : base(name, price) {
    expiresAt = expiresAtValue;
  }
  
  public DateTime GetExpiresAt () {
    return expiresAt;
  }
  
  public override string ToString () {
    return "FoodItem name='"+GetName()+"'"
                  +" price='"+GetPrice()+"'"
                  +" expiresAt='"+GetExpiresAt()+"'";
  }
  
  // comment out the Main method to use this class as the entry point of the program
  
  //public static void Main(string[] args) {
  //  FoodItem[] items = new FoodItem[10];
  //  
  //  for (int i=0 ; i<items.Length ; i++) {
  //    items[i] = new FoodItem($"Item {i}", 12.3 * i, DateTime.Now.AddDays(i));
  //  }
  //  
  //  foreach (FoodItem item in items) {
  //    Console.WriteLine(item);
  //  }
  //}
}
