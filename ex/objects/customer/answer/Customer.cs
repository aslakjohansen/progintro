public class Customer
{
  public string name;
  public int    id;
  public double balance;

  public Customer (string nameValue, int idValue, double balanceValue) {
    name    = nameValue;
    id      = idValue;
    balance = balanceValue;
  }
  
  public Customer (string nameValue, int idValue) {
    name    = nameValue;
    id      = idValue;
    balance = 0;
  }
  
  public void Deposit (double amount) {
    balance += amount;
  }
  
  public void Withdraw (double amount) {
    balance -= (balance > amount ? amount : 0);
  }
  
  public double GetBalance () {
    return balance;
  }
  
  public static void Main (string[] args) {
    Customer aCustomer;
    
    aCustomer = new Customer("Donald Knuth", 42, 0);
    Console.WriteLine(aCustomer.GetBalance());
    aCustomer.Deposit(1000);
    Console.WriteLine(aCustomer.GetBalance());
    aCustomer.Withdraw(500);
    Console.WriteLine(aCustomer.GetBalance());
  }
}
