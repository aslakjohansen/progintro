public class Program
{
  static void Main () {
    for (int i=1 ; i<6 ; i++){
      RaceCar   car   = new RaceCar("McQueen", 12, 5, 1.5);
      RaceHorse horse = new RaceHorse("Secretariat", 8, 5);
      Racer[] racers = [car, horse];
      Race(racers, 20*i, 1);
    }
  }
  
  private static void Race (Racer[] racers, double raceDistance, double playbackSpeed) {
    foreach (Racer racer in racers) {
      Console.WriteLine(racer.Name);
    }
    Thread.Sleep(1000);
    
    bool finished = false;
    while (!finished) {
      for (int i=0 ; i<40 ; i++) Console.WriteLine();
      foreach (Racer racer in racers) {
        double distance = racer.Race(playbackSpeed);
        for (int i=0 ; i<distance ; i++){
          Console.Write("-");
        }
        Console.WriteLine(racer.Name);
        if (distance >= raceDistance)
          finished = true;
      }
      Thread.Sleep(200);
      Console.WriteLine();
    }
  }
}
