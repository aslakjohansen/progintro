double slice_angle (int pcount) {
  // guard: count must be positive
  if (pcount<=0)
    return -1;
  
  return 360/pcount;
}

for (int pcount=-4 ; pcount<5 ; pcount++) {
  double angle = slice_angle(pcount);
  if (angle!=-1) {
    Console.WriteLine("Slices of "+angle+" degrees will feed "+pcount+" mouths");
  }
}
