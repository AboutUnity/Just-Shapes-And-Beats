namespace YNL.Extension.Objects
{
    [System.Serializable]
    public class Pair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public Pair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public void Assign(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}