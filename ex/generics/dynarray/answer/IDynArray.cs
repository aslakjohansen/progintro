interface IDynArray<T>
{
  void Append (T element);
  void Insert (int i, T element);
  void Remove (int i);
  void Set (int i, T element);
  T    Get (int i);
  int  GetFill ();
}
