using System.Collections.Generic;
using System.Linq;
using System;
using YNL.Utilities;
using System.Collections;

namespace YNL.Extension.Method
{
    public static class MArray
    {
        /// <summary> 
        /// Get random element in a array. 
        /// </summary>
        public static T GetRandom<T>(this T[] array)
        {
            if (array.Length == 0) throw new IndexOutOfRangeException("Array is empty.");
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        /// <summary> 
        /// Get amount of elements satisfy the condition in array. 
        /// </summary>
        public static int Count<T>(this T[] list, Func<T, bool> predicate)
            => list.Where(predicate).ToArray().Length;

        /// <summary>
        /// Shuffle an array.
        /// </summary>
        public static void Shuffle<T>(this T[] list)
        {
            for (var i = list.Length - 1; i > 1; i--)
            {
                var j = UnityEngine.Random.Range(0, i + 1);
                var value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }

        /// <summary>
        /// Return a array satisfies multiple predicates.
        /// </summary>
        public static IList<T> Wheres<T>(this T[] list, IList<Func<T, bool>> predicate)
        {
            List<T> newList = new List<T>();

            foreach (var item in predicate)
            {
                List<T> addList = list.Where(item).ToList();
                foreach (var element in addList) newList.Add(element);
            }

            return newList;
        }

        /// <summary>
        /// Check if an array is empty or not.
        /// </summary>
        public static bool IsEmpty<T>(this T[] array)
            => !array.IsNull() && array.Length <= 0 ? true : false;

        /// <summary>
        /// Swap 2 elements in an array.
        /// </summary>
        public static T[] Swap<T>(this T[] array, int indexA, int indexB)
        {
            T tmp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = tmp;
            return array;
        }

        /// <summary>
        /// Add a value to an array;
        /// </summary>
        public static T[] Add<T>(this T[] array, T value)
        {
            List<T> list = array.ToList();
            list.Add(value);
            array = list.ToArray();
            return array;
        }

        /// <summary>
        /// Get index of an element in an array.
        /// </summary>
        public static int IndexOf<T>(this T[] array, T element)
            => Array.IndexOf(array, element);

        /// <summary>
        /// Try get an element from an array.
        /// </summary>
        public static T TryGet<T>(this T[] array, int index)
        {
            if (array.IsNullOrEmpty()) return default;
            else return array[index];
        }
    }

    public static class MList
    {
        /// <summary> 
        /// Get random element in a list. 
        /// </summary>
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("List is empty!");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Get random element in a list but not the same with current.
        /// </summary>
        public static T GetRandomBut<T>(this IList<T> list, int current)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("List is empty!");
            int next = UnityEngine.Random.Range(0, list.Count);
            if (next == current) return list.GetRandomBut(current);
            else return list[next];
        }

        /// <summary>
        /// Remove random element in a list. Return that element.
        /// </summary>
        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("List is empty!");
            int index = UnityEngine.Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary> 
        /// Get amount of elements satisfy the condition in list. 
        /// </summary>
        public static int Count<T>(this IList<T> list, Func<T, bool> predicate)
            => list.Where(predicate).ToList().Count;

        /// <summary>
        /// Shuffle a list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = UnityEngine.Random.Range(0, i + 1);
                var value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }

        /// <summary>
        /// Return a list satisfies multiple predicates.
        /// </summary>
        public static List<T> Wheres<T>(this IList<T> list, IList<Func<T, bool>> predicate)
        {
            List<T> newList = new List<T>();

            foreach (var item in predicate)
            {
                List<T> addList = list.Where(item).ToList();
                foreach (var element in addList) newList.Add(element);
            }

            return newList;
        }

        /// <summary>
        /// Check if this item is the last item in list.
        /// </summary>
        public static bool IsLast<T>(this IList<T> list, T item)
        {
            if (list.IndexOf(item) >= list.Count - 1) return true;
            else return false;
        }

        /// <summary>
        /// Convenience way to declare a Foreach loop.
        /// </summary>
        public static void Foreach<T>(this IList<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }

        /// <summary>
        /// Check if a list is null or not.
        /// </summary>
        public static bool IsNull<T>(this IList<T> list)
            => list == null ? true : false;

        /// <summary>
        /// Check if a list is empty or not.
        /// </summary>
        public static bool IsEmpty<T>(this IList<T> list)
            => !list.IsNull() && list.Count <= 0 ? true : false;

        /// <summary>
        /// Check if a list is null or empty or not.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
            => list.IsNull() || list.IsEmpty() ? true : false;

        /// <summary>
        /// Add element if list doesn't contain it.
        /// </summary>
        public static IList<T> AddDistinct<T>(this IList<T> list, T element)
        {
            if (!list.Contains(element)) list.Add(element);
            return list;
        }

        /// <summary>
        /// Try to get an element from a list.
        /// </summary>
        public static T TryGet<T>(this List<T> list, int index)
        {
            if (index >= list.Count) return default;
            return list[index];
        }

        /// <summary>
        /// Try to remove element(s) from a list.
        /// </summary>
        public static IList<T> TryRemove<T>(this IList<T> list, T element)
        {
            if (list.Contains(element)) list.Remove(element);
            else MDebug.Caution("List does not contains element");
            return list;
        }
        public static IList<T> TryRemove<T>(this IList<T> list, params T[] elements)
        {
            foreach (var element in elements) list.TryRemove(element);
            return list;
        }
    }

    public static class MDictionary
    {
        /// <summary>
        /// Only use for Dictionary with value is bool. Will return false if dictionary doesn't contain given key.
        /// </summary>
        public static bool GetBool<K>(this Dictionary<K, bool> dictionary, K key)
        {
            if (!dictionary.ContainsKey(key)) return false;
            else return dictionary[key];
        }
    }
}