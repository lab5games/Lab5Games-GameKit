using System;
using System.IO;
using UnityEngine;

namespace Lab5Games
{
    public static class AppConfig
    {
        public static string savePath => GetSavePath();

        public static string readonlyPath => GetReadonlyPath();


        private static string GetSavePath()
        {
            string path = null;

#if UNITY_EDITOR
            path = Path.Combine(Environment.CurrentDirectory, "Library\\AppDevCache\\Save");
#else
            path = Path.Combine(Application.persistentDataPath, "Save");
#endif

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        private static string GetReadonlyPath()
        {
            return Application.streamingAssetsPath;
        }
    }
}
