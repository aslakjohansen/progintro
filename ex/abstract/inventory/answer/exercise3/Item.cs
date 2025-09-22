public abstract class Item : IExpirable
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
  
  public abstract bool IsExpired ();
}
