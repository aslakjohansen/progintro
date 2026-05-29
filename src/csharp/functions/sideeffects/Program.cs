int value = 1;

void incr () {
  value++;
}

void print_line (int length) {
  for (int i=0 ; i<length ; i++) {
    Console.Write("-");
  }
  Console.WriteLine("");
}

incr();
print_line(value);
