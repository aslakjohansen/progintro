for (int pcount=-4 ; pcount<5 ; pcount++) {
  double angle;
  
  if (pcount>0) {
    angle = 360/pcount;
  } else {
    angle = -1;
  }
  
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+pcount+" mouths");
  }
}
