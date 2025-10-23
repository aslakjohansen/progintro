using System;
using System.IO;

public class Turtle
{
  int x = 0;
  int y = 0;
  bool draw = false;
  Canvas canvas;
  
  public Turtle (Canvas canvas) {
    this.canvas = canvas;
  }
  
  public void Raise () {
    draw = false;
    Draw();
  }
  
  public void Lower () {
    draw = true;
    Draw();
  }
  
  public void GoN () {
    y -= 1;
    Draw();
  }
  
  public void GoS () {
    y += 1;
    Draw();
  }
  
  public void GoW () {
    x -= 1;
    Draw();
  }
  
  public void GoE () {
    x += 1;
    Draw();
  }
  
  public void GoNE () {
    x += 1;
    y -= 1;
    Draw();
  }
  
  public void GoSE () {
    x += 1;
    y += 1;
    Draw();
  }
  
  public void GoSW () {
    x -= 1;
    y -= 1;
    Draw();
  }
  
  public void GoNW () {
    x -= 1;
    y -= 1;
    Draw();
  }
  
  public void Draw () {
    canvas.SetValue(x, y, canvas.GetValue(x, y) || draw);
  }
  
  public static void Main (string[] args)
  {
    Canvas canvas;
    Turtle turtle;
    
    // guard: command line arguments
    if (args.Length != 3) {
      Console.WriteLine("Syntax: dotnet run WIDTH HEIGHT FILENAME");
      Console.WriteLine("        dotnet run 11 12 ../house.turtle");
      return;
    }
    int width  = int.Parse(args[0]);
    int height = int.Parse(args[1]);
    string filename = args[2];
    
    canvas = new Canvas(width, height);
    turtle = new Turtle(canvas);
    
    // open file
    StreamReader file = new StreamReader(filename);
    string? line;
    while ((line = file.ReadLine()) != null) {
      switch (line) {
        case "go north":
          turtle.GoN();
          break;
        case "go south":
          turtle.GoS();
          break;
        case "go east":
          turtle.GoE();
          break;
        case "go west":
          turtle.GoW();
          break;
        case "go north-east":
          turtle.GoNE();
          break;
        case "go south-east":
          turtle.GoSE();
          break;
        case "go south-west":
          turtle.GoSW();
          break;
        case "go north-west":
          turtle.GoNW();
          break;
        case "pen up":
          turtle.Raise();
          break;
        case "pen down":
          turtle.Lower();
          break;
        default:
          Console.WriteLine("Warning. Unrecognized command '"+line+"'. Skipping ...");
          break;
      }
    }
    file.Close();
    
    // print result
    canvas.Print();
  }
}
