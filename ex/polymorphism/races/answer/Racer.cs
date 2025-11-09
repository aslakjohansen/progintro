public class Racer
{
  public    string Name;
  protected double speed;
  protected double distance;
  
  public Racer (string name, double speed) {
    Name = name;
    this.speed = speed;
  }
  
  public virtual double Race (double time) {
    distance += speed * time;
    return distance;
  }
}
