class NonFoodItem : Item {
  public string[] materials;
  
  public NonFoodItem (string name, double price, string[] materialsValue)
       : base(name, price) {
      materials = materialsValue;
  }
  
  public string[] GetMaterials () {
    return materials;
  }
  
  public override string ToString () {
    string m = "[";
    for (int i=0 ; i<materials.Length ; i++) {
      m += (i == 0 ? "" : ",") + materials[i];
    }
    m += "]";
    return "NonFoodItem name='" + GetName()
         + "' price='" + GetPrice()
         + "' materials='" + m + "'";
  }
  
  // comment out the Main method to use this class as the entry point of the program
  
  //public static void Main (string[] args)
  //{
  //  NonFoodItem[] items = new NonFoodItem[10];
  //  
  //  for (int i=0 ; i<items.Length ; i++) {
  //    items[i] = new NonFoodItem("Item " + i, 12.3 * i,
  //                               new string[] { "butter", "cream" });
  //  }
  //  
  //  foreach (NonFoodItem item in items) {
  //    Console.WriteLine(item);
  //  }
  //}
}
