#include <stdio.h>

#define unless(cond) if(!(cond))

int main (int argc, char* argv[]) {
  unless (argc==1) {
    printf("Has arguments!\n");
  }
  
  return 0;
}
