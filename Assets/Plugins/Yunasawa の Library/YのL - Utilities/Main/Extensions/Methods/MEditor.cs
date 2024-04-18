#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using YNL.Extension.Constant;

namespace YNL.Extension.Method
{
    public class MGUILayout
    {
        public class ColorScope : IDisposable
        {
            public ColorScope(Color color, string type = "color")
            {
                switch (type)
                {
                    case "": break;
                    case "color":
                        GUI.color = color;
                        break;
                    case "content":
                        GUI.contentColor = color;
                        break;
                    case "background":
                        GUI.backgroundColor = color;
                        break;
                    case "color, content":
                        GUI.color = color;
                        GUI.contentColor = color;
                        break;
                    case "color, background":
                        GUI.color = color;
                        GUI.backgroundColor = color;
                        break;
                    case "content, background":
                        GUI.contentColor = color;
                        GUI.backgroundColor = color;
                        break;
                    case "all":
                        GUI.color = color;
                        GUI.contentColor = color;
                        GUI.backgroundColor = color;
                        break;
                }
            }

            public void Dispose()
            {
                GUI.color = Color.white;
                GUI.backgroundColor = Color.white;
                GUI.contentColor = Color.white;
            }
        }
        public class VerticalScope : IDisposable
        {
            public VerticalScope(params GUILayoutOption[] options)
            {
                GUILayout.BeginVertical(options);
            }
            public VerticalScope(GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginVertical(style, options);
            }
            public VerticalScope(string text, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginVertical(text, style, options);
            }
            public VerticalScope(Texture image, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginVertical(image, style, options);
            }
            public VerticalScope(GUIContent content = null, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginVertical(content, style, options);
            }
            public VerticalScope(Color color, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(options);
                GUI.color = Color.white;
            }
            public VerticalScope(Color color, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(style, options);
                GUI.color = Color.white;
            }
            public VerticalScope(string text, Color color, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(text, style, options);
                GUI.color = Color.white;
            }
            public VerticalScope(string text, Color color, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(text, options);
                GUI.color = Color.white;
            }
            public VerticalScope(Texture image, Color color, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(image, style, options);
                GUI.color = Color.white;
            }
            public VerticalScope(Color color, GUIContent content = null, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginVertical(content, style, options);
                GUI.color = Color.white;
            }

            public void Dispose()
            {
                GUILayout.EndVertical();
            }
        }
        public class HorizontalScope : IDisposable
        {
            public HorizontalScope(params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(options);
            }
            public HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(style, options);
            }
            public HorizontalScope(string text, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(text, style, options);
            }
            public HorizontalScope(Texture image, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(image, style, options);
            }
            public HorizontalScope(GUIContent content = null, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(content, style, options);
            }
            public HorizontalScope(Color color, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(options);
                GUI.color = Color.white;
            }
            public HorizontalScope(Color color, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(style, options);
                GUI.color = Color.white;
            }
            public HorizontalScope(string text, Color color, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(text, style, options);
                GUI.color = Color.white;
            }
            public HorizontalScope(string text, Color color, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(text, options);
                GUI.color = Color.white;
            }
            public HorizontalScope(Texture image, Color color, GUIStyle style, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(image, style, options);
                GUI.color = Color.white;
            }
            public HorizontalScope(Color color, GUIContent content = null, GUIStyle style = null, params GUILayoutOption[] options)
            {
                GUI.color = color;
                GUILayout.BeginHorizontal(content, style, options);
                GUI.color = Color.white;
            }

            public void Dispose()
            {
                GUILayout.EndHorizontal();
            }
        }
        public class ScrollViewScope : IDisposable
        {
            public ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options)
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, options);
            }

            public void Dispose()
            {
                GUILayout.EndScrollView();
            }
        }

        public static Rect GetRect(Rect alignment)
        {
            GUILayout.Space(0);
            return new Rect(GUILayoutUtility.GetLastRect().x + alignment.x, GUILayoutUtility.GetLastRect().y + alignment.y, alignment.width, alignment.height);
        }
        public static Rect GetRect(int x, int y, int width, int height)
            => GetRect(new Rect(x, y, width, height));

        public static void LinkLabel(string labelText, Color labelColor, string webAddress)
            => MEditorUtilities.LinkLabel(labelText, labelColor, 12, webAddress);
        public static void LinkLabel(string labelText, Color labelColor, int fontSize, string webAddress)
            => MEditorUtilities.LinkLabel(labelText, labelColor, fontSize, webAddress);

        public static void Label(string label, Color color, GUIStyle style = null, params GUILayoutOption[] options)
        {
            using (new ColorScope(color, "content"))
            {
                GUILayout.Label(label, style, options);
            }
        }
        public static void Label(string label, Color color, params GUILayoutOption[] options)
        {
            using (new ColorScope(color, "content"))
            {
                GUILayout.Label(label, options);
            }
        }

        public static bool ToolbarToggle(ref bool toggle, string label, params GUILayoutOption[] options)
        {
            Color toggleColor = toggle ? Color.white : new Color(0.975f, 0.975f, 0.975f, 1);
            using (new MGUILayout.ColorScope(toggleColor, "background"))
            {
                toggle = GUILayout.Toggle(toggle, label, "ToolbarButton", options);
            }
            return toggle;
        }

        public static string SearchField(string label, params GUILayoutOption[] options)
        {
            var cbSize = new Vector2(EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
            var rect = EditorGUILayout.BeginHorizontal();
            var result = EditorGUILayout.TextField(label, EditorStyles.toolbarSearchField, options);
            //if (!string.IsNullOrEmpty(key) && CancelButton(GetNewRect(rect, cbSize, new Vector2(1f, 1f), rect.width - cbSize.y))) { result = ""; }
            EditorGUILayout.EndHorizontal();
            return result;
        }

        public static bool CancelButton(Rect rect, string tooltip = null, params GUILayoutOption[] options)
        {
            GUIContent iconButton = EditorGUIUtility.TrIconContent("Toolbar Minus", tooltip);
            if (GUILayout.Button(iconButton, "SearchCancelButton", options)) { return true; }
            return false;
        }

        public static void ShowPopupWindowAtMouse(PopupWindowContent content)
        {
            Vector2 mousePosition = Event.current.mousePosition;
            mousePosition = new Vector2(mousePosition.x, mousePosition.y / 2);
            PopupWindow.Show(new Rect(mousePosition, mousePosition), content);
        }
    }

    public class MEditorGUI
    {
        /// <summary>
        /// Draw a Rect. <br></br>
        /// <br></br>
        /// Alignment: position by x and y, size by width and height. <br></br>
        /// Color: color of rect. <br></br>
        /// Space: space after rect. <br></br>
        /// </summary>
        public static void DrawRect(Rect alignment, Color color, int space)
        {
            GUILayout.Space(0);
            Rect rect = new Rect(GUILayoutUtility.GetLastRect().x + alignment.x, GUILayoutUtility.GetLastRect().y + alignment.y, alignment.width, alignment.height);
            EditorGUI.DrawRect(rect, color);
            GUILayout.Space(space);
        }

        /// <summary>
        /// Draw a Toolbox. <br></br>
        /// <br></br>
        /// Alignment: position by x and y, size by width and height. <br></br>
        /// Color: color of rect. <br></br>
        /// Space: space after rect. <br></br>
        /// </summary>
        public static void DrawToolbox(Rect align, int space = 0, float thickness = 1)
        {
            GUILayout.Space(0);
            Rect lastRect = GUILayoutUtility.GetLastRect();
            Rect outLine = new Rect(lastRect.x + align.x, lastRect.y + align.y, align.width, align.height);
            Rect mainRect = new Rect(lastRect.x + thickness + align.x, lastRect.y + thickness / 3 * 2 + 0.5f + align.y, align.width - thickness * 3 / 2, align.height - thickness * 3 / 2);
            EditorGUI.DrawRect(outLine, "282828".ToColor());
            EditorGUI.DrawRect(mainRect, "383838".ToColor());
            if (space != -1) GUILayout.Space(space);
        }
    }

    public static class MEditorUtilities
    {
        /// <summary>
        /// </summary>
        /// Sources: https://forum.unity.com/threads/im-going-to-teach-you-guys-how-to-create-link-labels-for-the-unity-editor.513606/
        public static bool LinkLabel(string labelText, Color labelColor, int fontSize)
        {
            GUIStyle style = EditorStyles.label;

            Color textColor = style.normal.textColor;
            int size = style.fontSize;

            style.normal.textColor = labelColor;
            style.fontSize = fontSize;

            try
            {
                return GUILayout.Button(labelText, style);
            }
            finally
            {
                style.normal.textColor = textColor;
                style.fontSize = size;
            }
        }
        public static void LinkLabel(string labelText, Color labelColor, int fontSize, string webAddress)
        {
            if (LinkLabel(labelText, labelColor, fontSize))
            {
                try
                {
                    Application.OpenURL(@webAddress);
                }
                catch
                {
                    Debug.LogError("Could not open URL. Please check your network connection and ensure the web address is correct.");
                }
            }
        }

    }
}
#endif