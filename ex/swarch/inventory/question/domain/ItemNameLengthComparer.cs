namespace Domain
{
  class ItemNameLengthComparer : IComparer<Item>
  {
    public int Compare (Item? i1, Item? i2) {
      if (i1==null) return  1;
      if (i2==null) return -1;
      return i1.Name.Length - i2.Name.Length;
    }
  }
}
