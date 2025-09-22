class FoodItem : Item
{
  private DateTime expires;
  
  public FoodItem (string name, double price, DateTime expires) : base(name, price) {
    this.expires = expires;
  }
  
  public DateTime GetExpires () {
    return expires;
  }
  
  public override bool IsExpired () {
    return DateTime.Now > expires;
  }
  
  public override string ToString () {
    return "FoodItem name='"+GetName()+"'"
                  +" price='"+GetPrice()+"'"
                  +" expires='"+GetExpires()+"'";
  }
}
