int[][] jagged = [
  [1],
  [2,3],
  [3,4,5],
  [4,5,6,7]
];

for (int y=0 ; y<jagged.Length ; y++) {
  for (int x=0 ; x<jagged[y].Length ; x++) {
    Console.WriteLine("jagged["+y+"]["+x+
                      "] = "+jagged[y][x]);
  }
}
