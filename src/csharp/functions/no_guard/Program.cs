double slice_angle (int pcount) {
  if (pcount>0) {
    return 360/pcount;
  } else {
    return -1;
  }
}

for (int pcount=-4 ; pcount<5 ; pcount++) {
  double angle = slice_angle(pcount);
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+pcount+" mouths");
  }
}
