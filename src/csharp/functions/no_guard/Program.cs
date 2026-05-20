double slice_angle (int mouth_count) {
  if (mouth_count>0) {
    return 360/mouth_count;
  } else {
    return -1;
  }
}

for (int mouth_count=-4 ; mouth_count<5 ; mouth_count++) {
  double angle = slice_angle(mouth_count);
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+mouth_count+" mouths");
  }
}
