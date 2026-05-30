void fun () {
  int a = 1;
  int b = 2;
  
  void operation () {
    a += b;
  }
  
  operation();
  Console.WriteLine(a);
}

fun();
