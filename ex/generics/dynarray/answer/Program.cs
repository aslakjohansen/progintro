IDynArray<int> a = new DynArray<int>();

Console.WriteLine("Add elements:");
Console.WriteLine(a);
for (int i=0 ; i<20 ; i++) {
  a.Append(i);
  Console.WriteLine(a);
}
Console.WriteLine("");

Random random = new Random();
Console.WriteLine("Remove elements:");
Console.WriteLine(a);
for (int i=19 ; i>=0 ; i--) {
  a.Remove(random.Next(a.GetFill()));
  Console.WriteLine(a);
}
