int[] accounts = {903, 716, 67};

int GetAccountNumber ()
{
  Console.WriteLine("Enter an account number: ");
  while (true) {
    try {
      return Convert.ToInt32(Console.ReadLine());
    } catch (FormatException) {
      Console.WriteLine("I'm afraid that I don't understand. Please try again: ");
    }
  }
  
}

void PrintAccountState (int accountId)
{
  Console.WriteLine("Account " + accountId + " contains " + accounts[accountId]);
}


while (true)
{
  int accountId = GetAccountNumber();
  try {
    PrintAccountState(accountId);
  } catch (IndexOutOfRangeException) {
    Console.WriteLine("Unknown account: " + accountId);
  }
}
