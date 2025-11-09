public class RaceHorse : Racer
{
  private double stamina;
  
  public RaceHorse (string name, double speed, double stamina) : base(name, speed) {
    this.stamina = stamina;
  }
  
  public override double Race (double time) {
    speed -= time / stamina;
    speed = (speed>2 ? speed : 2);
    return base.Race(time);
  }
}
