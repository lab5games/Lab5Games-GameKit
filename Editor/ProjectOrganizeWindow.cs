using UnityEngine;
using UnityEditor;
using System.IO;
using NUnit.Framework.Constraints;
using System;

namespace Lab5Games.Ediotr
{
    public class ProjectOrganizeWindow : EditorWindow
    {
        private const float PAD_SIZE = 2f;

        private static readonly Vector2 windowSize = new Vector2(400, 120);
        private static readonly float lineHeight = EditorGUIUtility.singleLineHeight;
        private static readonly float paddedLine = lineHeight + PAD_SIZE;

        private string m_InputProjectName = "_Project";


        [MenuItem(EditorConstants.MenuNameBase + "/Project Organization")]
        private static void CreateWindow()
        {
            var window = GetWindow<ProjectOrganizeWindow>(true, "Project Organization");
            window.maxSize = windowSize;
            window.minSize = windowSize;
            window.Show();
        }

        private void OnEnable()
        {
            m_InputProjectName = "_Project";
        }

        private void OnGUI()
        {
            Rect position = new Rect(new Vector2(10, 25), new Vector2(windowSize.x - 10, lineHeight));
            EditorGUI.LabelField(position, new GUIContent("Project Name"), EditorStyles.boldLabel);

            position.x += 100;
            position.width -= 125;
            m_InputProjectName = EditorGUI.TextField(position, m_InputProjectName);

            position = new Rect(new Vector2(windowSize.x - 105, windowSize.y -2 * paddedLine - 5), new Vector2(80, 2 * lineHeight));
            if(GUI.Button(position, new GUIContent("Organize")))
            {
                OrganizeProjectFolders();
                Close();
            }
        }

        void OrganizeProjectFolders()
        {
            if (string.IsNullOrEmpty(m_InputProjectName))
                throw new NullReferenceException("Project name cannot be null");

            string[] folders = new string[]
            {
                "Assets/{0}/Art/Animations",
                "Assets/{0}/Art/Materials",
                "Assets/{0}/Art/Models",
                "Assets/{0}/Art/Textures",
                "Assets/{0}/Art/UI",
                "Assets/{0}/Art/Fonts",

                "Assets/{0}/Audio/Musics",
                "Assets/{0}/Audio/Sounds",

                "Assets/{0}/Code/Scripts",
                "Assets/{0}/Code/Shaders",

                "Assets/{0}/Content/Prefabs",
                "Assets/{0}/Content/Scenes",
                "Assets/{0}/Content/Scriptables",
                "Assets/{0}/Content/Settings",

                "Assets/{0}/Doc",

                "Assets/ThirdParty"
            };


            foreach (string folder in folders)
            {
                string path = string.Format(folder, m_InputProjectName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            AssetDatabase.Refresh();
        }
    }
}
