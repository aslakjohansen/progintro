Point2D p0 = new Point2D(0, 0);
Point2D p1 = new Point2D(1, 1);
LineSegment<Point2D> l = new LineSegment<Point2D>(p0, p1);
Console.WriteLine(p0.DistanceTo(p1));
