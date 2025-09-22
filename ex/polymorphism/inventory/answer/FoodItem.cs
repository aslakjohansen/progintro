class FoodItem : Item
{
  private DateTime expiresAt;
  
  public FoodItem (string name, double price, DateTime expiresAt) : base(name, price) {
    this.expiresAt = expiresAt;
  }
  
  public DateTime GetExpiresAt () {
    return expiresAt;
  }
  
  public override string ToString () {
    return "FoodItem name='"+GetName()+"'"
                  +" price='"+GetPrice()+"'"
                  +" expiresAt='"+GetExpiresAt()+"'";
  }
}
