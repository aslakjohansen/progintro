using Domain;

namespace Presentation
{
  class Test
  {
    public static void Add () {
      Item i1 = new NonFoodItem("USB_Charger", 17.45,
                                new string[] { "plastic", "stuff" });
      
      Inventory inventory = new Inventory();
      inventory.Load("inventory.txt");
      inventory.AddItem(i1);
      inventory.Store("inventory.txt");
    }
    
    public static void List () {
      Inventory inventory = new Inventory();
      inventory.Load("inventory.txt");
      inventory.PrintInventory();
    }
    
    public static void Main (string[] args) {
      Add();
      List();
    }
  }
}
