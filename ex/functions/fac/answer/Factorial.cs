int fac (int i) {
  if (i < 0) {
    Console.WriteLine("That was not very nice of you!");
  }
  
  if (i > 0) {
    return i * Fac(i - 1);
  } else {
    return 1;
  }
}

for (int i = 1 ; i < 10 ; i++) {
  Console.WriteLine(" fac(" + i + ") = " + fac(i));
}
