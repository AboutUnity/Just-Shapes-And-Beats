using UnityEngine;

namespace YNL.Extension.Method
{
    public static class MComponent
    {
        /// <summary>
        /// Get all attached component of type T in a gameObject;
        /// </summary>
        public static T[] GetAttachedComponent<T>(this GameObject gameObject) where T : Component
            => gameObject.GetComponents<T>();
        public static T[] GetAttachedComponent<T>(this MonoBehaviour mono) where T : Component
            => mono.GetComponents<T>();

        /// <summary> 
        /// Disable all Monobehavior script in an object. 
        /// </summary>
        public static void DisableAllComponent<T>(this GameObject thisObject, T component) where T : Behaviour
        {
            T[] scripts = thisObject.GetComponents<T>();
            foreach (T script in scripts) script.enabled = false;
        }
        public static void DisableAllComponent<T>(this MonoBehaviour mono, T component) where T : Behaviour
            => mono.gameObject.DisableAllComponent(component);

        /// <summary>
        /// Get component from an object. If there's not, add the component.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null) component = gameObject.AddComponent<T>();
            return component;
        }
        public static T GetOrAddComponent<T>(this MonoBehaviour mono) where T : Component
            => mono.gameObject.GetOrAddComponent<T>();

        /// <summary>
        /// Check if an object has the component or not.
        /// </summary>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
            => gameObject.GetComponent<T>() != null;
        public static bool HasComponent<T>(this MonoBehaviour mono) where T : Component
            => mono.gameObject.HasComponent<T>();
    }
}