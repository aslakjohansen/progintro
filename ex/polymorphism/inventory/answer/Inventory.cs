public class Inventory
{
  private Item[] items;
  
  public Inventory (Item[] items) {
    this.items = items;
  }
  
  public Inventory () : this(new Item[0]) {
  }
  
  public void AddItem (Item item) {
    if (!Contains(items, item)) {
      Item[] newItems = new Item[items.Length+1];
      
      for (int i=0 ; i<items.Length ; i++) {
        newItems[i] = items[i];
      }
      newItems[items.Length] = item;
      
      items = newItems;
    }
  }
  
  public void RemoveItem (Item item) {
    if (Contains(items, item)) {
      Item[] newItems = new Item[items.Length-1];
      
      int i = 0;
      for ( ; items[i]!=item ; i++) {
        newItems[i] = items[i];
      }
      for ( i++ ; i<items.Length ; i++) {
        newItems[i-1] = items[i];
      }
      
      items = newItems;
    }
  }
  
  public double GetInventory () {
    double total = 0.0;
    
    foreach (Item item in items) {
      total += item.GetPrice();
    }
    
    return total;
  }
  
  public void PrintInventory () {
    Console.WriteLine("Inventory:");
    foreach (Item item in items) {
      Console.WriteLine(" - " + item);
    }
  }
  
  private bool Contains (Item[] items, Item item) {
    foreach (Item candidateItem in items) {
      if (candidateItem==item) return true;
    }
    return false;
  }
}
