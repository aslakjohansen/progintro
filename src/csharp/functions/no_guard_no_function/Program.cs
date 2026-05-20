for (int mouth_count=-4 ; mouth_count<5 ; mouth_count++) {
  double angle;
  
  if (mouth_count>0) {
    angle = 360/mouth_count;
  } else {
    angle = -1;
  }
  
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+mouth_count+" mouths");
  }
}
