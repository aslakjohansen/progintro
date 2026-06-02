int[] intArr = new int[12];
int[] oneArr = fill(intArr, 1);

int[] fill (int[] array, int value) {
  for (int i=0 ; i<array.Length ; i++) {
    array[i] = value;
  }
  
  return array;
}
