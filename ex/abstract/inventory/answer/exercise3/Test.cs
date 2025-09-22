public class Test
{
  public static void TestFoodItem () {
    FoodItem[] items = new FoodItem[10];
    
    for (int i=0; i<items.Length ; i++)
    {
       items[i] = new FoodItem($"Item {i}", 12.3 * i, DateTime.Now.AddDays(i));
    }
    
    foreach (FoodItem item in items)
    {
       Console.WriteLine(item);
    }
  }
  
  public static void TestNobFoodItem () {
    NonFoodItem[] items = new NonFoodItem[10];
    
    for (int i=0 ; i<items.Length ; i++) {
      items[i] = new NonFoodItem("Item " + i,
                                 12.3 * i,
                                 new string[] { "butter", "cream" });
    }
    
    foreach (NonFoodItem item in items) {
      Console.WriteLine(item);
    }
  }
  
  public static void PrintStatus (Inventory inventory) {
    inventory.PrintInventory();
    Console.WriteLine("Total: " + inventory.GetInventory());
    Console.WriteLine();
  }
  
  public static void Main (string[] args) {
    Inventory inventory = new Inventory();
    Item i1 = new FoodItem("Milk", 12.95, new DateTime());
    Item i2 = new NonFoodItem("USB Charger", 17.45,
                              new string[] { "plastic", "stuff" });
    Item[] items = new Item[] { i1, i2 };
    
    PrintStatus(inventory);
    foreach (Item item in items) {
      inventory.AddItem(item);
      PrintStatus(inventory);
    }
    
    inventory.RemoveItem(i1);
    PrintStatus(inventory);
  }
}
