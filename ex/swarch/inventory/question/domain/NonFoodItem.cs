namespace Domain
{
  public class NonFoodItem : Item
  {
    public List<string> Materials { get; set; }
    
    public static NonFoodItem? Unmarshal (string[] args) {
      if (args.Length != 4) return null;
      
      string name = args[1];
      double price = double.Parse(args[2]);
      string[] Materials = args[3].Split(',');
      return new NonFoodItem(name, price, Materials);
    }
    
    public NonFoodItem (string name, double price, List<string> materials)
         : base(name, price) {
      this.Materials = materials;
    }
    
    public NonFoodItem (string name, double price, string[] materials)
         : base(name, price) {
      this.Materials = new List<string>(materials);
    }
    
    public override bool IsExpired () {
      throw new NotSupportedException("Item does not support this operation.");
    }
    
    public override string ToString () {
      string m = "[";
      for (int i=0 ; i<Materials.Count ; i++) {
          m += (i == 0 ? "" : ",") + Materials[i];
      }
      m += "]";
      return "NonFoodItem name='"+Name+"' price='"+Price+"' Materials='"+m+"'";
    }
    
    public override string GetItemType () {
      return "NonFoodItem";
    }
    
    public override string[] GetState () {
      return new string[] { Name, ""+Price, string.Join(",", Materials) };
    }
    
    // self-test
    public static void Test () {
      NonFoodItem[] items = new NonFoodItem[10];
      
      for (int i=0 ; i<items.Length ; i++) {
        items[i] = new NonFoodItem("Item "+i, 12.3 * i,
                                   new string[] { "butter", "cream" });
      }
      
      foreach (NonFoodItem item in items) {
        Console.WriteLine(item);
      }
    }
  }
}
