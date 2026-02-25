Point2D p20 = new Point2D(0, 0);
Point2D p21 = new Point2D(1, 1);
LineSegment<Point2D> l2 = new LineSegment<Point2D>(p20, p21);
Console.WriteLine(l2.GetLength());

Point3D p30 = new Point3D(0, 0, 0);
Point3D p31 = new Point3D(1, 1, 1);
LineSegment<Point3D> l3 = new LineSegment<Point3D>(p30, p31);
Console.WriteLine(l3.GetLength());
