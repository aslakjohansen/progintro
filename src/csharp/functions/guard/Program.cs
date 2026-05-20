double slice_angle (int mouth_count) {
  // guard: count must be positive
  if (mouth_count<=0)
    return -1;
  
  return 360/mouth_count;
}

for (int mouth_count=-4 ; mouth_count<5 ; mouth_count++) {
  double angle = slice_angle(mouth_count);
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+mouth_count+" mouths");
  }
}
