public abstract class Item
{
  private string name;
  private double price;
  
  public Item (string name, double price) {
    this.name = name;
    this.price = price;
  }
  
  public string GetName () {
    return name;
  }
  
  public double GetPrice () {
    return price;
  }
}
