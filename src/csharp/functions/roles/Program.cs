int b (int parameter) {
  return parameter;
}

int a (int parameter) {
  return b(parameter);
}

Console.WriteLine(a(42));
