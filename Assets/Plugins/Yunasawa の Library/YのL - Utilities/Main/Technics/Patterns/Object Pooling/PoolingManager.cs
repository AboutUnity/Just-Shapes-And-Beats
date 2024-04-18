using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YNL.Extension.Method;

namespace YNL.Technic.ObjectPooling
{
    public static class PoolingManager
    {
        public static void PoolingSpawn<T>(this List<T> list, T origin, Transform parent, Vector3 position, Quaternion quaternion, Action<T, int> onComplete) where T : MonoBehaviour
            => list.Spawn(origin, parent, position, quaternion, onComplete);
        public static void PoolingSpawn<T>(this List<T> list, T origin, Transform parent, Action<T, int> onComplete) where T : MonoBehaviour
            => list.Spawn(origin, parent, Vector3.zero, Quaternion.identity, onComplete);

        public static void Spawn<T>(this List<T> list, T origin, Transform parent, Vector3 position, Quaternion quaternion, Action<T, int> onComplete) where T : MonoBehaviour
        {
            int disabledAmount = list.Count(i => !i.gameObject.activeSelf);
            int enabledAmount = list.Count - disabledAmount;

            T prefab;

            if (disabledAmount <= 0)
            {
                prefab = GameObject.Instantiate(origin, position, quaternion, parent);
                list.Add(prefab);
            }
            else
            {
                prefab = list[enabledAmount];
                prefab.gameObject.SetActive(true);
            }

            enabledAmount++;
            onComplete?.Invoke(prefab, enabledAmount);
        }
    }
}