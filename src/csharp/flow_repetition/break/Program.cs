int limit = 50;
int root = 1;

while (true) {
  if (root*root>limit) break;
  root++;
}

Console.WriteLine(root*root);
