#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;


namespace JungleFrog.Editor
{
    public static class EditorMethods
    {
        private static void ShowArray(SerializedProperty list, string sufix, GUIContent content, string[] names)
        {
            for (int i = 0; i < list.arraySize; i++)
            {
                content.text = ObjectNames.NicifyVariableName($"{names[i]} {sufix}");

                SerializedProperty element = list.GetArrayElementAtIndex(i);
                if (!string.IsNullOrEmpty(sufix))
                {
                    if (element.objectReferenceValue != null)
                    {
                        element.objectReferenceValue.name = content.text;
                    }
                }
                EditorGUILayout.PropertyField(element, content);
            }
        }

        public static void SetupArray<T>(int size, SerializedProperty list, string sufix)
        {
            GUIContent content = new GUIContent();

            SetupArray<T>(size, list, sufix, content);
        }

        public static void SetupArray<T>(int size, SerializedProperty list, string sufix, GUIContent content)
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException();
            }

            if (!list.isArray)
            {
                return;
            }
            string[] names = Enum.GetNames(typeof(T));

            if (list.arraySize < size)
            {
                Debug.Log($"Increased {typeof(T)} size from {list.arraySize} to {size}");
                int start = list.arraySize;
                for (int i = start; i < size; i++)
                {
                    list.InsertArrayElementAtIndex(i);

                    SerializedProperty element = list.GetArrayElementAtIndex(i);
                    if (element.objectReferenceValue != null)
                    {
                        element.objectReferenceValue = null;
                    }
                }
            }
            else if (list.arraySize > size & false)
            {
                Debug.Log($"Decreased {typeof(T)} size from {list.arraySize} to {size}");
                for (int i = size; i < list.arraySize; i++)
                {
                    list.DeleteArrayElementAtIndex(i);
                }
            }

            list.arraySize = size;
            ShowArray(list, sufix, content, names);
        }
    }

#endif
}
