class NonFoodItem : Item
{
  private string[] materials;
  
  public NonFoodItem (string name, double price, string[] materials)
       : base(name, price) {
    this.materials = materials;
  }
  
  public string[] GetMaterials () {
    return materials;
  }
  
  public override bool IsExpired () {
    return false;
  }
  
  public override string ToString () {
    string m = "[";
    for (int i=0 ; i<materials.Length ; i++) {
        m += (i == 0 ? "" : ",") + materials[i];
    }
    m += "]";
    
    return "NonFoodItem name='"+GetName()+"' price='"+GetPrice()+"' materials='"+m+"'";
  }
}
