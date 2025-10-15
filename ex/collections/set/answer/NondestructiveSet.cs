interface NondestructiveSet<T> : ISet<T>
{
  NondestructiveSet<T> Intersection (NondestructiveSet<T> other);
  NondestructiveSet<T> Union (NondestructiveSet<T> other);
  NondestructiveSet<T> Difference (NondestructiveSet<T> other);
}
