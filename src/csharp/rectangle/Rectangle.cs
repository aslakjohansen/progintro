Rectangle r = new Rectangle {CenterX=1 , CenterY=2, Width=3, Height=4};
Console.WriteLine(rectangle_area(r));
Console.WriteLine(rectangle_circumference(r));

double rectangle_area (Rectangle r) {
  return r.Width * r.Height;
}

double rectangle_circumference (Rectangle r) {
  return 2*r.Width + 2*r.Height;
}

void rectangle_move_to (Rectangle r, double x, double y) {
  r.CenterX = x;
  r.CenterY = y;
}

class Rectangle {
  public double CenterX, CenterY;
  public double Width, Height;
}
