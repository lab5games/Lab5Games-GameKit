using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using Newtonsoft.Json;
using UnityEngine;

namespace Lab5Games.Ediotr
{
    // https://qiita.com/sune2/items/a88cdee6e9a86652137c
    // https://www.bzetu.com/413/.html
    // https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProvider.html

    public class ToolkitEditorSettingsProvider : SettingsProvider
    {
        ToolkitEditorSettings m_Settings;
        
        const string SettingPath = "Project/Lab5 Toolkit";
        
        public static readonly string SettingAssetPath = Path.Combine(Environment.CurrentDirectory, "ProjectSettings/Lab5ToolkitSettings.json");


        [SettingsProvider]
        static SettingsProvider CreateProvider()
        {
            return new ToolkitEditorSettingsProvider(SettingPath, SettingsScope.Project, null);
        }

        public ToolkitEditorSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
            GetOrCreateSettings();
        }

        private void GetOrCreateSettings()
        {
            if(File.Exists(SettingAssetPath))
            {
                using(FileStream stream = new FileStream(SettingAssetPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        m_Settings = JsonConvert.DeserializeObject<ToolkitEditorSettings>(json);
                    }
                }
            }
            
            if(m_Settings == null)
            {
                m_Settings = new ToolkitEditorSettings();
            }
        }
       
        private void SaveSettings()
        {
            using(FileStream stream = new FileStream(SettingAssetPath, FileMode.OpenOrCreate))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(m_Settings);
                    writer.Write(json);

                    Debug.LogWarning("Save settings");
                }
            }
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.Space(15);
            EditorGUI.BeginChangeCheck();

            m_Settings.autoBuildVersion = EditorGUILayout.Toggle("Auto Build Version", m_Settings.autoBuildVersion);

            if(EditorGUI.EndChangeCheck())
            {
                SaveSettings();    
            }

            EditorGUILayout.Space(6);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Save Path");
            EditorGUILayout.LabelField(AppConfig.savePath);
            if (GUILayout.Button("Cleanup", GUILayout.Width(80)))
            {
                DirectoryInfo dir = new DirectoryInfo(AppConfig.savePath);

                if(dir.Exists)
                {
                    foreach(var file in dir.GetFiles())
                    {
                        file.Delete();
                    }

                    foreach(var subDir in dir.GetDirectories())
                    {
                        subDir.Delete(true);
                    }
                }

                Debug.LogWarning("Cleanup save path");
            }
            EditorGUILayout.EndHorizontal();
        }
    }



    public class ToolkitEditorSettings 
    {
        public bool autoBuildVersion;

    }
}
