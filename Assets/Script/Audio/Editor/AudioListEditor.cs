#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using JungleFrog.Editor;



namespace JungleFrog.Audio.Editor
{
    [CustomEditor(typeof(SoundEffectList))]
    [CanEditMultipleObjects]
    public class AudioListEditor : UnityEditor.Editor
    {
        private const string arrayName = "effects";

        private SerializedProperty prefabs;
        private GUIContent content;

        private int size;

        void OnEnable()
        {
            size = Enum.GetValues(typeof(SoundEffect)).Length;
            content = new GUIContent();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            prefabs = serializedObject.FindProperty(arrayName);

            EditorMethods.SetupArray<SoundEffect>(size, prefabs, string.Empty);


            serializedObject.ApplyModifiedProperties();
        }
    } 
}
#endif