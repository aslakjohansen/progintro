
const double pi = 3.14;
double r, c;
double s = 0.0;

r = 1;
c = 2.0 * pi * r;
s += c;
Console.WriteLine("r=" + r + " -> circumference=" + c);

r = 3;
c = 2.0 * pi * r;
s += c;
Console.WriteLine("r=" + r + " -> circumference=" + c);

r = 5;
c = 2.0 * pi * r;
s += c;
Console.WriteLine("r=" + r + " -> circumference=" + c);

Console.WriteLine("Sum is " + s);