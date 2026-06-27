int input = 3;
Console.WriteLine("input is "+input);
if ((input&1)==1) {
  Console.WriteLine("input is odd. Let me fix that for you ...");
  input += 1;
}
Console.WriteLine("input is "+input);
