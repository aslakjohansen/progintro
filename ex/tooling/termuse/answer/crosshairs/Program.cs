char character;

while (true) {
  int width  = Console.WindowWidth;
  int height = Console.WindowHeight;
  
  for (int y=0 ; y<height ; y++) {
    for (int x=0 ; x<width ; x++) {
      if (y==height/2 && x==width/2) {
        character = '+';
      } else if (y==height/2) {
        character = '-';
      } else if (x==width/2) {
        character = '|';
      } else {
        character = ' ';
      }
        
      Console.Write(character);
    }
    Console.WriteLine("");
  }
  
  Thread.Sleep(1000);
}
