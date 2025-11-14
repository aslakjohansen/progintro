World world = new World();
Ball ball = new Ball(world, 1, 1);
world.Run();

public class World {
  List<Ball> balls;
  public int width;
  public int height;
  char[,] cells;
  
  public World () {
    this.balls = new List<Ball>();
    this.width = Console.WindowWidth;
    this.height = Console.WindowHeight;
    this.cells = new char[height, width];
  }
  
  public void AddBall (Ball ball) {
    balls.Add(ball);
  }
  
  void Clear () {
    for (int y=0 ; y<height ; y++) {
      for (int x=0 ; x<width ; x++) {
        cells[y, x] = ' ';
      }
    }
  }
  
  public void PlaceBall (int x, int y) {
    cells[y, x] = 'O';
  }
  
  void Render () {
    for (int y=0 ; y<height ; y++) {
      for (int x=0 ; x<width ; x++) {
        Console.Write(cells[y, x]);
      }
      Console.WriteLine("");
    }
  }
  
  void Step () {
    foreach (Ball ball in balls) {
      ball.Step();
    }
  }
  
  public void Run () {
    while (true) {
      Render();
      Clear();
      Step();
      Thread.Sleep(100);
    }
  }
}

public class Ball {
  World world;
  int x, y;
  int dx, dy;
  
  public Ball (World world, int dx, int dy) {
    this.world = world;
    this.x = 0;
    this.y = 0;
    this.dx = dx;
    this.dy = dy;
    world.AddBall(this);
  }
  
  public void Step () {
    if ((dx>0 && x+dx>=world.width)  || (dx<0 && x+dx<0)) dx *= -1;
    if ((dy>0 && y+dy>=world.height) || (dy<0 && y+dy<0)) dy *= -1;
    
    x += dx;
    y += dy;
    
    world.PlaceBall(x,y);
  }
}
