char direction = 'N';

switch (direction) {
  case 'N':
    Console.WriteLine("Going north ...");
    break;
  case 'S':
    Console.WriteLine("Going south ...");
    break;
  case 'E':
    Console.WriteLine("Going east ...");
    break;
  case 'W':
    Console.WriteLine("Going west ...");
    break;
  default:
    Console.WriteLine("I don't understand ?!?");
    break;
}
