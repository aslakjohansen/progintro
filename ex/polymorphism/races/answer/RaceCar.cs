public class RaceCar : Racer
{
  private double fuel;
  private double fuelEfficiency;
  
  public RaceCar (string name, double speed, double fuel, double fuelEfficiency)
       : base (name, speed) {
    this.fuel = fuel;
    this.fuelEfficiency = fuelEfficiency;
  }
  
  public override double Race (double time) {
    fuel -= time / fuelEfficiency;
    if (fuel <= 0)
      speed = 0;
    return base.Race(time);
  }
}
