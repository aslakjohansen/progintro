public class Happiness
{
  const int ITEM_PRICE  = 6000;
  const int ITEM_COUNT  =   15;
  const int HOUSE_VALUE = 8000;
  
  static int  account   = 30000;
  static bool ownsHouse = true;
  
  static bool AccountIsPositive () {
    return account>0;
  }
  
  static bool BuyItem (int price) {
    account -= price;
    return AccountIsPositive();
  }
  
  // returns true if able to sell house or no sale necessary
  static bool SellHouseIfNecessary () {
    if (!AccountIsPositive()) {
      if (!ownsHouse) return false;
      
      account += HOUSE_VALUE;
      ownsHouse = false;
    }
    return true;
  }
  
  static void PrintState () {
    Console.WriteLine("account="+account+" ownsHouse="+ownsHouse);
  }
  
  public static void Main (String[] args) {
    bool happy;
    
    for (int i=0 ; i<ITEM_COUNT ; i++) {
      happy =  (AccountIsPositive() && BuyItem(ITEM_PRICE))
            || SellHouseIfNecessary();
      Console.WriteLine("I am "+(happy ? "" : "not ")
                       +"happy and my account is "+account);
    }
  }
}
