#include <stdio.h>

#define DEFAULT (12)
#define RADIUS2DIAMETER(r) ((r)*2)

int main (int argc, char* argv[]) {
  int radius = DEFAULT*MULTIPLIER;
  int diameter = RADIUS2DIAMETER(radius);
  printf("r=%d => d=%d\n", radius, diameter);
  
  return 0;
}

