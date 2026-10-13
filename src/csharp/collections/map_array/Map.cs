using System.Collections.Generic;

class Map<K,V> where K : notnull {
  private List<Pair<K,V>> list = new List<Pair<K,V>>();
  
  public void Add (K key, V val) {
    Remove(key);
    list.Add(new Pair<K,V>(key, val));
  }
  
  public bool Remove (K key) {
    for (int i=0 ; i<list.Count ; i++) {
      Pair<K,V> pair = list[i];
      if (pair!=null && pair.key.Equals(key)) {
        list.RemoveAt(i);
        return true;
      }
    }
    return false;
  }
}

class Pair<K,V> {
  public K key;
  public V val;
  
  public Pair (K key, V val) {
    this.key = key;
    this.val = val;
  }
}
