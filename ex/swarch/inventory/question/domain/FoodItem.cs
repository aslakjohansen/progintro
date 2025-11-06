namespace Domain
{
  public class FoodItem : Item
  {
    private DateTime ExpiresAt;
    
    public static FoodItem? Unmarshal (string[] args) {
      if (args.Length != 4) return null;
      
      string name = args[1];
      double price = double.Parse(args[2]);
      DateTime date;
      
      try {
        date = DateTime.Parse(args[3]);
      } catch (FormatException) {
        return null;
      }
      
      try {
        return new FoodItem(name, price, date);
      } catch (ExpiredItemAddedException) {
        return null;
      }
    }
    
    public FoodItem (string name, double price, DateTime expiresAt)
         : base(name, price) {
      this.ExpiresAt = expiresAt;
      if (IsExpired()) {
        throw new ExpiredItemAddedException();
      }
    }
    
    public override string ToString () {
      return "FoodItem name='"+Name+"' price='"+Price+"' ExpiresAt='"+ExpiresAt+"'";
    }
    
    public override bool IsExpired () {
      return ExpiresAt.CompareTo(DateTime.Now) < 0;
    }
    
    public override string GetItemType () {
      return "FoodItem";
    }
    
    public override string[] GetState () {
      return new string[] { Name, Price.ToString(), ExpiresAt.ToString() };
    }
    
    // self-test
    public static void Test () {
      FoodItem?[] items = new FoodItem[10];
      
      for (int i=0 ; i<items.Length ; i++) {
        try {
          items[i] = new FoodItem("Item " + i, 12.3 * i, DateTime.Now.AddDays(i * 30));
        } catch (ExpiredItemAddedException) {
          items[i] = null;
        }
      }
      
      foreach (FoodItem? item in items) {
        Console.WriteLine(item);
      }
    }
  }
}
