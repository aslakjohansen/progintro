using Data;

namespace Domain
{
  public class Inventory
  {
    private List<Item> items;
    
    public Inventory (List<Item> items) {
      this.items = items;
    }
    
    public Inventory () {
      this.items = new List<Item>();
    }
    
    public bool Load (string filename) {
      FileBackend fb = new FileBackend(filename);
      if (fb == null) return false;
      
      List<string> entries = fb.Load();
      if (entries == null) return false;
      
      foreach (string entry in entries) {
        Item? item = Item.Unmarshal(entry);
        if (item != null) AddItem(item);
      }
      
      return true;
    }
    
    public bool Store (string filename) {
      FileBackend fb = new FileBackend(filename);
      if (fb == null) return false;
      
      List<string> entries = new List<string>();
      foreach (Item item in items) {
        entries.Add(item.Marshal());
      }
      
      return fb.Store(entries);
    }
    
    public void AddItem (Item item) {
      if (!items.Contains(item)) {
        items.Add(item);
      }
    }
    
    public void RemoveItem (Item item) {
      items.Remove(item);
    }
    
    public double GetInventory () {
      double total = 0.0;
      
      foreach (Item item in items) {
        total += item.Price;
      }
      
      return total;
    }
    
    public void PrintInventory () {
      Console.WriteLine("Inventory:");
      foreach (Item item in items) {
        Console.WriteLine(" - " + item);
      }
    }
    
    public static void PrintStatus (Inventory inventory) {
      inventory.PrintInventory();
      Console.WriteLine("Total: " + inventory.GetInventory());
      Console.WriteLine("");
    }
    
    public void RemoveExpiredFoods () {
      for (int i=0 ; i<items.Count ; i++) {
        Item item = items[i];
        try {
          bool expired = item.IsExpired();
          if (expired) {
            items.Remove(item);
          }
        } catch (NotSupportedException e) {
          Console.WriteLine("Item "+item.Name+" does not support this operation: "+
                            e.Message);
          return;
        }
      }
    }
    
    public List<Item> SortedByNameLength () {
      List<Item> result = new List<Item>(items);
      result.Sort(new ItemNameLengthComparer());
      return result;
    }
    
    public List<Item> SortedByPrice () {
      List<Item> result = new List<Item>(items);
      result.Sort();
      return result;
    }
    
    public static FoodItem? SafeFoodItem (string name, double price, DateTime date) {
      try {
        return new FoodItem(name, price, date);
      } catch (ExpiredItemAddedException e) {
        Console.WriteLine("Item " + name + " is expired: " + e.Message);
        return null;
      }
    }
    
    // self-test
    public static void Test () {
      Inventory inventory = new Inventory();
      Item? i1 = SafeFoodItem("chocolate", 19.95, DateTime.Now.AddDays(1));
      Item? i2 = SafeFoodItem("coffee", 24.95, DateTime.Now.AddDays(1));
      Item? i3 = SafeFoodItem("Milk", 12.95, DateTime.Now.AddDays(1));
      Item? i4 = SafeFoodItem("Egg", 4.95, DateTime.Now.AddTicks(100));
      Item? i5 = new NonFoodItem("USB Charger", 17.45,
                                 new string[] { "plastic", "stuff" });
      Item?[] items = new Item?[] { i1, i2, i3, i4, i5 };
      
      PrintStatus(inventory);
      foreach (Item? item in items) {
        // guard: don't add null values
        if (item == null) continue;
        
        inventory.AddItem(item);
        Console.WriteLine("Adding " + item);
        PrintStatus(inventory);
      }
      
      Console.WriteLine("Sorting by name length:");
      foreach (Item? i in inventory.SortedByNameLength()) {
        Console.WriteLine(" - " + i.Name + " (" + i.Price + ")");
      }
      Console.WriteLine("");
      PrintStatus(inventory);
      
      Console.WriteLine("Sorting by price:");
      foreach (Item i in inventory.SortedByPrice()) {
        Console.WriteLine(" - " + i.Name + " (" + i.Price + ")");
      }
      Console.WriteLine("");
      PrintStatus(inventory);
      
      if (i1!=null) inventory.RemoveItem(i1);
      PrintStatus(inventory);
      
      inventory.RemoveExpiredFoods();
      PrintStatus(inventory);
    }
  }
}
