using UnityEngine;

namespace YNL.Utilities
{
    [System.Serializable]
    public class ObjectPair<K, V> where K : class where V : class
    {
        [SerializeField] private K _key;
        public K Key => _key;
        [SerializeField] private V _value;
        public V Value => _value;

        public ObjectPair(K key, V value)
        {
            _key = key;
            _value = value;
        }

        public void Change(K key, V value)
        {
            _key = key;
            _value = value;
        }

        public void Remove(K key, V value)
        {
            _key = null;
            _value = null;
        }
    }
}