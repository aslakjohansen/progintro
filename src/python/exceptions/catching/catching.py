#!/usr/bin/env python

try:
  raise Exception("Oops!")
except Exception as e:
  print(e)
print("But still alive ...")
