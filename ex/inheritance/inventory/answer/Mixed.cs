class Mixed
{
  // comment out the Main method to use this class as the entry point of the program
  static void Main (string[] args) {
    Item[] items = new Item[10];
    
    for (int i=0 ; i<items.Length ; i++) {
      if (i % 2 == 0) {
        items[i] = new FoodItem("Item " + i, 12.3 * i,
                                new DateTime(i * 1000 * 60 * 60 * 24));
      } else {
        items[i] = new NonFoodItem("Item " + i, 12.3 * i,
                                   new string[] { "butter", "cream" });
      }
    }
    
    foreach (Item item in items) {
      Console.WriteLine(item);
    }
  }
}
