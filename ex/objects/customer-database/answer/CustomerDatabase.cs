class CustomerDatabase
{
  Customer[] customers;
  
  public CustomerDatabase () {
    customers = new Customer[10];
  }
  
  public bool Add (Customer customer) {
    for (int i = 0; i < customers.Length; i++) {
      if (customers[i] == null) {
        customers[i] = customer;
        return true;
      }
    }
    return false;
  }
  
  public void Remove (int id) {
    for (int i = 0; i < customers.Length; i++) {
      if (customers[i] != null && customers[i].id == id) {
        customers[i] = null;
      }
    }
  }
  
  public Customer[] Get () {
    return (Customer[])customers.Clone();
  }
  
  public void Print () {
    foreach (Customer c in customers) {
      if (c == null) continue;
      Console.WriteLine(c.name);
    }
  }
  
  public static void Main (string[] args) {
    CustomerDatabase db = new CustomerDatabase();
    
    Console.WriteLine("Result:" + db.Add(new Customer("Alan Turing", 1912)));
    Console.WriteLine("Result:" + db.Add(new Customer("Ada Lovelace", 1815)));
    Console.WriteLine("Result:" + db.Add(new Customer("Charles Babbage", 1791)));
    Console.WriteLine("Result:" + db.Add(new Customer("Donald Knuth", 1938)));
    Console.WriteLine("Result:" + db.Add(new Customer("Grace Hopper", 1906)));
    Console.WriteLine("Result:" + db.Add(new Customer("Edsger Dijkstra", 1930)));
    Console.WriteLine("Result:" + db.Add(new Customer("Tony Hoare", 1934)));
    Console.WriteLine("Result:" + db.Add(new Customer("Hedy Lamarr", 1914)));
    Console.WriteLine("Result:" + db.Add(new Customer("Michael Stonebraker", 1943)));
    Console.WriteLine("Result:" + db.Add(new Customer("Jim Gray", 1944)));
    Console.WriteLine("Result:" + db.Add(new Customer("Douglas Engelbart", 1925))); // Should fail because array length is 10
    Console.WriteLine();
    
    db.Print();
  }
}
