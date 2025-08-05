int i = 127;
Console.WriteLine("int i = "+i);

long l = i;
Console.WriteLine("long l = "+l);

i = (int)l;
Console.WriteLine("i (cast from long to int) = "+i);

float f = 3.14F;
Console.WriteLine("float f = "+f);

double d = f;
Console.WriteLine("double d = "+d);

f = (float)d;
Console.WriteLine("f (cast from double to float) = "+f);

f = i;
Console.WriteLine("f (cast from int i to long) = "+f);

i = (int)f;
Console.WriteLine("i (cast from float to double) = "+i);
