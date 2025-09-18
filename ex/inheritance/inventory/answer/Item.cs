class Item {
  public string name;
  public double price;
  
  public Item (string nameValue, double priceValue)
  {
    name  = nameValue;
    price = priceValue;
  }
  
  public string GetName ()
  {
    return name;
  }
  
  public double GetPrice ()
  {
    return price;
  }
}
