public class Pin
{
  const int CRITICAL_AMOUNT = 350;
  const int MAX_TRANSACTIONS = 4;
  private int time2pin = MAX_TRANSACTIONS;
  
  bool Expend (int amount) {
    if (time2pin==0 || amount>CRITICAL_AMOUNT) {
      time2pin = MAX_TRANSACTIONS;
    }
    return amount > CRITICAL_AMOUNT || --time2pin == 0;
  }
  
  public static void Main(string[] args) {
    int[] amount_edges = { 350, 351 };
    int[] transact_edges = { -1, 0, 1 };
    
    foreach (int amount in amount_edges) {
      foreach (int transact_count in transact_edges) {
        Pin pin = new Pin();
        bool result = true;
        for (int i=0; i<MAX_TRANSACTIONS-transact_count ; i++) {
          result = pin.Expend(amount);
        }
        Console.WriteLine("a=" + amount + " t=" + transact_count + " r=" + result);
      }
    }
  }
}
