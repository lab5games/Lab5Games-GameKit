using UnityEngine;
using UnityEditor;
using DG.DOTweenEditor;
using Lab5Games.UI;

namespace Lab5Games.UI.Ediotr
{
    [CustomEditor(typeof(UI.UITweener))]
    public class UITweenerEditor : UnityEditor.Editor
    {
        SerializedProperty go;
        
        SerializedProperty animType;
        SerializedProperty easeType;
        SerializedProperty animCurve;

        SerializedProperty duration;
        SerializedProperty delay;

        SerializedProperty loops;
        SerializedProperty loopType;

        SerializedProperty endValueFloat;
        SerializedProperty endValueV3;
        SerializedProperty endValueColor;

        SerializedProperty isRelative;
        SerializedProperty playOnEnable;

        bool previewIsPlaying = false;

        private void OnEnable()
        {
            go = serializedObject.FindProperty("target");

            animType = serializedObject.FindProperty("animType");
            easeType = serializedObject.FindProperty("easeType");
            animCurve = serializedObject.FindProperty("animCurve");

            duration = serializedObject.FindProperty("duration");
            delay = serializedObject.FindProperty("delay");

            loops = serializedObject.FindProperty("loops");
            loopType = serializedObject.FindProperty("loopType");

            endValueFloat = serializedObject.FindProperty("endValueFloat");
            endValueV3 = serializedObject.FindProperty("endValueV3");
            endValueColor = serializedObject.FindProperty("endValueColor");

            isRelative = serializedObject.FindProperty("isRelative");
            playOnEnable = serializedObject.FindProperty("playOnEnable");
        }

        private void OnDisable()
        {
            if(previewIsPlaying)
            {
                StopForPreview();
            }
        }

        private void PlayForPreview()
        {
            UITweener tweener = (target as UI.UITweener);

            tweener.Play();

            if (tweener.tween != null)
            {
                previewIsPlaying = true;
                DOTweenEditorPreview.PrepareTweenForPreview(tweener.tween);
                DOTweenEditorPreview.Start();
            }
        }

        private void StopForPreview()
        {
            (target as UI.UITweener).Stop();

            previewIsPlaying = false;
            DOTweenEditorPreview.Stop(true, true);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlaying);
            {
                serializedObject.Update();

                EditorGUILayout.PropertyField(go, new GUIContent("Target"));

                EditorGUILayout.Space(7);
                EditorGUILayout.PropertyField(animType);
                EditorGUILayout.PropertyField(easeType);

                if (easeType.enumValueIndex == 0)
                    EditorGUILayout.PropertyField(animCurve);

                EditorGUILayout.Space(7);
                EditorGUILayout.PropertyField(duration);
                EditorGUILayout.PropertyField(delay);
                EditorGUILayout.PropertyField(loops);
                EditorGUILayout.PropertyField(loopType);

                EditorGUILayout.Space(7);
                switch (animType.enumValueIndex)
                {
                    case 0:
                    case 1:
                        EditorGUILayout.PropertyField(endValueV3);
                        break;
                    case 2:
                        EditorGUILayout.PropertyField(endValueFloat);
                        break;
                    case 3:
                        EditorGUILayout.PropertyField(endValueColor);
                        break;
                }

                EditorGUILayout.PropertyField(isRelative, new GUIContent("Relative"));
                EditorGUILayout.PropertyField(playOnEnable);

                serializedObject.ApplyModifiedProperties();

                EditorGUILayout.Space(14);
                GUI.enabled = !previewIsPlaying;
                if (GUILayout.Button(new GUIContent("Play Preview")))
                {
                    PlayForPreview();
                }

                GUI.enabled = previewIsPlaying;
                if (GUILayout.Button(new GUIContent("Stop Preview")))
                {
                    StopForPreview();
                }
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}
