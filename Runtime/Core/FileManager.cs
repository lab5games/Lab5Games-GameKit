using System;
using System.IO;
using UnityEngine;

namespace Lab5Games
{
    public static class FileManager
    {

        /*
         * Unity Editor: <path to project folder>/Assets
         * 
         * iOS player: <path to player app bundle>/<AppName.app>/Data (this folder is read only, use Application.persistentDataPath to save data).
         * 
         * Win/Linux player: <path to executablename_Data folder> (note that most Linux installations will be case-sensitive!)
         * 
         * WebGL: The absolute url to the player data file folder (without the actual data file name)
         * 
         * Android: Normally it points directly to the APK. If you are running a split binary build, it points to the OBB instead.
         */
        public static string GetUnityDataPath()
        {
            return Application.dataPath;
        }

        /*
         * Most platforms (Unity Editor, Windows, Linux players) use Application.dataPath + "/StreamingAssets"
         * 
         * macOS player uses Application.dataPath + "/Resources/Data/StreamingAssets"
         * 
         * iOS uses Application.dataPath + "/Raw"
         * 
         * Android uses files inside a compressed APK/JAR file, "jar:file://" + Application.dataPath + "!/assets"
         */
        public static string GetUnityStreamingAssetsPath()
        {
            return Application.streamingAssetsPath;
        }

        public static string GetUnityPersistentDataPath()
        {
#if UNITY_EDITOR

            string path = Path.Combine(Environment.CurrentDirectory, "Library\\TempAppPersistentDataPath");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;

#else

            return Application.persistentDataPath;
#endif
        }


        public static bool Save(string path, string content)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            if(!Directory.Exists(path))
            {
                GameLogger.Log($"[FileManager] Directory folder does not exist, path= {path}", GameLogger.LogLevel.Error);
                return false;
            }

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(content);

                        GameLogger.Log($"[FileManager] The file has been saved, path= {path}", GameLogger.LogLevel.System);
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                GameLogger.Log($"[FileManager] Failed to save file with an exception: {e.Message}", GameLogger.LogLevel.Exception);
                return false;
            }
        }

        public static bool Load(string path, out string content)
        {
            content = null;

            if(!File.Exists(path))
            {
                GameLogger.Log($"[FileManager] The file does not exist, path= {path}", GameLogger.LogLevel.Error);
                return false;
            }

            try
            {
                using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using(StreamReader reader = new StreamReader(fs))
                    {
                        content = reader.ReadToEnd();

                        GameLogger.Log($"[FileManager] The file has been loaded", GameLogger.LogLevel.System);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                GameLogger.Log($"[FileManager] Failed to load file with an exception: {ex.Message}", GameLogger.LogLevel.Exception);
                return false;
            }
        }
    }
}
