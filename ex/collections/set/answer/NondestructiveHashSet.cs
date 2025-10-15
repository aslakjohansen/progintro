class NondestructiveHashSet<T> : HashSet<T>, NondestructiveSet<T>
{
  public NondestructiveHashSet () { }
  
  public NondestructiveHashSet (T[] elements)
  {
    foreach (T element in elements) {
      Add(element);
    }
  }
  
  public NondestructiveSet<T> Intersection (NondestructiveSet<T> other) {
    NondestructiveSet<T> result = new NondestructiveHashSet<T>();
    result.UnionWith(this);
    result.IntersectWith(other);
    return result;
  }
  
  public NondestructiveSet<T> Union (NondestructiveSet<T> other) {
    NondestructiveSet<T> result = new NondestructiveHashSet<T>();
    result.UnionWith(this);
    result.UnionWith(other);
    return result;
  }
  
  public NondestructiveSet<T> Difference (NondestructiveSet<T> other) {
    NondestructiveSet<T> result = new NondestructiveHashSet<T>();
    result.UnionWith(this);
    result.ExceptWith(other);
    return result;
  }
  
  public override string ToString () {
    return "{" + string.Join(", ", this) + "}";
  }
}
