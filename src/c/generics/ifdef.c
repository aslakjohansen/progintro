#include <stdio.h>
#include <sys/time.h>

#define ITERATION_COUNT (1<<30)

double time_diff (struct timeval t0, struct timeval t1)
{
  double t0_us = (double)t0.tv_sec * 1000000 + (double)t0.tv_usec;
  double t1_us = (double)t1.tv_sec * 1000000 + (double)t1.tv_usec;
  return (t1_us - t0_us)/1000000;
}

int main (int argc, char* argv[]) {
#ifdef BENCHMARK
  struct timeval t0, t1;
  gettimeofday(&t0, NULL);
#endif

  for (long i=0 ; i<ITERATION_COUNT ; i++) ;
  
#ifdef BENCHMARK
  gettimeofday(&t1, NULL);
  printf("Performed %u iterations in %fs\n", ITERATION_COUNT, time_diff(t0, t1));
#endif
  
  return 0;
}

