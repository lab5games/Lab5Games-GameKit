using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;
using Newtonsoft.Json;

namespace Lab5Games.Ediotr
{
    public class AutoBuildAppVersion : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        bool m_AutoBuildVer = false;

        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report)
        {
            ReadSettings();

            if (m_AutoBuildVer)
            {
                BuildAppVer();
            }
        }

        void ReadSettings()
        {
            m_AutoBuildVer = false;

            if(File.Exists(ToolkitEditorSettingsProvider.SettingAssetPath))
            {
                using (FileStream stream = new FileStream(ToolkitEditorSettingsProvider.SettingAssetPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        var settings = JsonConvert.DeserializeObject<ToolkitEditorSettings>(json);

                        if(settings != null)
                        {
                            m_AutoBuildVer = settings.autoBuildVersion;
                        }
                    }
                }
            }
        }
        
        void BuildAppVer()
        {
            string bundleVer = PlayerSettings.bundleVersion;
            string[] arrVer = bundleVer.Split('.');

            if (arrVer.Length != 3)
            {
                arrVer = new string[] { "0", "0", "1" };
            }

            int.TryParse(arrVer[0], out int major);
            int.TryParse(arrVer[0], out int minor);
            int.TryParse(arrVer[0], out int build);

            PlayerSettings.bundleVersion = string.Format("{0}.{1}.{2}", major, minor, build);

            GameLogger.Log("[AutoBuildAppVersion] Build application version: " + PlayerSettings.bundleVersion, GameLogger.LogLevel.System);
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            if(m_AutoBuildVer)
            {
                ReplaceNewAppVer();
            }
        }

        private void ReplaceNewAppVer()
        {
            string bundleVer = PlayerSettings.bundleVersion;
            string[] arrVer = bundleVer.Split('.');

            if (arrVer.Length != 3)
            {
                throw new System.Exception("Invalid version format: " + PlayerSettings.bundleVersion);
            }

            int major, minor, build;

            int.TryParse(arrVer[0], out major);
            int.TryParse(arrVer[1], out minor);
            int.TryParse(arrVer[2], out build);

            PlayerSettings.bundleVersion = string.Format("{0}.{1}.{2}", major, minor, build + 1);

            EditorApplication.ExecuteMenuItem("File/Save Project");

            GameLogger.Log("[AutoBuildAppVersion] Replace new application version: " + PlayerSettings.bundleVersion, GameLogger.LogLevel.System);
        }
    }
}
