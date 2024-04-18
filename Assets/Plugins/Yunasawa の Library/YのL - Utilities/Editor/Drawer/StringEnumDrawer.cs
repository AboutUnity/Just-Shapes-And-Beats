#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YNL.Extension.Method;

namespace YNL.Extension.Objects
{
    [CustomPropertyDrawer(typeof(StringEnum))]
    public class ListToPopupDrawer : PropertyDrawer
    {
        int _selectedIndex;
        int _buttonSize = 30;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects) return 0f;
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects) return;

            var arrayProperty = property.FindPropertyRelative("Array");
            var labelProperty = property.FindPropertyRelative("Label");
            var indexProperty = property.FindPropertyRelative("Index");

            _selectedIndex = indexProperty.intValue;

            string[] array = new string[arrayProperty.arraySize];

            var labelRect = new Rect(position.x, position.y, position.width - _buttonSize, position.height);
            var indexRect = new Rect(position.x + position.width - _buttonSize + 2, position.y, _buttonSize - 2, position.height);

            for (int i = 0; i < array.Length; i++) array[i] = $"{i}: {arrayProperty.GetArrayElementAtIndex(i).stringValue}";

            if (!array.IsNullOrEmpty())
            {
                _selectedIndex = EditorGUI.Popup(labelRect, property.name, _selectedIndex, array);
                if (_selectedIndex >= array.Length) _selectedIndex = array.Length - 1;
                labelProperty.stringValue = array[_selectedIndex];
                indexProperty.intValue = _selectedIndex;
                if (_selectedIndex.ToString().Length == 1) _buttonSize = 20;
                if (_selectedIndex.ToString().Length == 2) _buttonSize = 27;
                GUI.Button(indexRect, _selectedIndex.ToString());
            }
            else _selectedIndex = EditorGUI.Popup(labelRect, property.name, _selectedIndex, new string[1] { "..." });
        }
    }
}
#endif