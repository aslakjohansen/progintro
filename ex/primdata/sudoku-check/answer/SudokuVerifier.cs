// test cases
int[][] puzzle = new int[][] {
  new int[] {7, 3, 6, 4, 5, 2, 9, 8, 1},
  new int[] {1, 9, 8, 6, 3, 7, 4, 5, 2},
  new int[] {4, 2, 5, 9, 8, 1, 3, 7, 6},
  new int[] {3, 6, 4, 5, 2, 8, 1, 9, 7},
  new int[] {9, 5, 2, 7, 1, 4, 6, 3, 8},
  new int[] {8, 1, 7, 3, 9, 6, 2, 4, 5},
  new int[] {2, 8, 9, 1, 7, 3, 5, 6, 4},
  new int[] {6, 7, 3, 2, 4, 5, 8, 1, 9},
  new int[] {5, 4, 1, 8, 6, 9, 7, 2, 3}
};
//int[][] puzzle = {
//  new int[] {7, 3, 6, 4, 5, 2, 9, 8, 1},
//  new int[] {1, 9, 8, 6, 3, 7, 4, 5, 2},
//  new int[] {4, 2, 5, 9, 8, 4, 3, 7, 6},
//  new int[] {3, 6, 4, 5, 2, 8, 1, 9, 7},
//  new int[] {9, 5, 2, 7, 1, 4, 6, 3, 8},
//  new int[] {8, 1, 7, 3, 9, 6, 2, 4, 5},
//  new int[] {2, 8, 9, 1, 7, 3, 5, 6, 4},
//  new int[] {6, 7, 3, 2, 4, 5, 8, 1, 9},
//  new int[] {5, 4, 1, 8, 6, 9, 7, 2, 3},
//};

bool correct = true;

// check rows
for (int y=0 ; y<9 ; y++) {
  for (int x=0 ; x<9 ; x++) {
    for (int x2=x+1 ; x2<9 ; x2++) {
      if (puzzle[y][x] == puzzle[y][x2]) {
        correct = false;
      }
    }
  }
}

// check columns
for (int x=0 ; x<9 ; x++) {
  for (int y=0 ; y<9 ; y++) {
    for (int y2=y+1 ; y2<9 ; y2++) {
      if (puzzle[y][x] == puzzle[y2][x]) {
        correct = false;
      }
    }
  }
}

// check groups
for (int x=0 ; x<3 ; x++) {
  for (int y=0 ; y<3 ; y++) {
    for (int i=0 ; i<9 ; i++) {
      int ix = i % 3;
      int iy = i / 3;
      for (int i2=i+1 ; i2<9 ; i2++) {
        int i2x = i2 % 3;
        int i2y = i2 / 3;
        if (puzzle[y*3+iy][x*3+ix] == puzzle[y*3+i2y][x*3+i2x]) {
          correct = false;
        }
      }
    }
  }
}

Console.WriteLine("Puzzle is " + (correct ? "correct" : "incorrect"));
