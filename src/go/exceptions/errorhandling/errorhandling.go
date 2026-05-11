package main

import "os"

func main() {
  f, err := os.Open("input.txt")
  if err != nil {
      // handle error
  }
  defer f.Close()
  
  // do something with f
}
