IntList? list = null;

for (int i=10 ; i>=0 ; i--)
  list = intlist_prepend(list, i);

intlist_print(list);
list = intlist_insert(list, 1, 42);
intlist_print(list);
Console.WriteLine("head:"+intlist_head(list));
Console.WriteLine("Tail:"+intlist_tail(list));

int intlist_index (IntList? list, int i) {
  if (list==null) return -1;
  if (i==0) return list.payload;
  return intlist_index(list.next, i-1);
}

IntList? intlist_prepend (IntList? list, int payload) {
  return new IntList {payload=payload, next=list};
}

int intlist_head (IntList? list) {
  return list==null ? -1 : list.payload;
}

IntList? intlist_tail (IntList? list) {
  return list==null ? null : list.next;
}

IntList? intlist_insert (IntList? list, int index, int payload) {
  // guard: insert as first element
  if (index==0) return intlist_prepend(list, payload);
  
  // find location
  IntList? current = list;
  for (int i=index-1 ; i>0 ; i--)
    if (current!=null)
      current = current.next;
  
  // perform update
  if (current!=null)
    current.next = intlist_prepend(current.next, payload);
  
  return list;
}

void intlist_print (IntList? list) {
  Console.Write("[ ");
  while (list != null) {
    Console.Write(list.payload+" ");
    list = list.next;
  }
  Console.WriteLine("];");
}

class IntList {
  public int payload;
  public IntList? next;
}
