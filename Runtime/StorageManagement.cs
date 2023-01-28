using System;
using System.IO;
using Newtonsoft.Json;

namespace Lab5Games
{
    public static class StorageManagement 
    {
        public static string dataPath
        {
            get
            {
                string path = UnityEngine.Application.persistentDataPath;

#if UNITY_EDITOR
                path = Path.Combine(Environment.CurrentDirectory + "Library/AppStorageCache");
#endif

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        public static bool CheckFile(string path)
        {
            path = Path.Combine(dataPath, path);
            return File.Exists(path);
        }

        public static bool DeleteFile(string path)
        {
            try
            {
                path = Path.Combine(dataPath, path);
                File.Delete(path);

                GameLogger.Log("[StorageManagement] Succssed to delete file", GameLogger.LogLevel.System);
                return true;
            }
            catch(Exception e)
            {
                GameLogger.Log($"[StorageManagement] Failed to delete file with exception: {e.Message}", GameLogger.LogLevel.Exception);
                return false;
            }
        }

        public static bool Cleanup()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dataPath);

                foreach (FileInfo file in dir.GetFiles())
                    file.Delete();

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                    subDir.Delete(true);

                GameLogger.Log("[StorageManagement] Successed to cleanup storage data", GameLogger.LogLevel.System);
                return true;
            }
            catch(Exception e)
            {
                GameLogger.Log($"[StorageManagement] Failed to cleanup storage data with exception: {e.Message}", GameLogger.LogLevel.Exception);
                return false;
            }
        }

        public static bool Save(string path, object saveData)
        {
            try
            {
                path = Path.Combine(dataPath, path);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        var json = JsonConvert.SerializeObject(saveData);
                        writer.Write(json);

                        GameLogger.Log($"[StorageManagement] Successed to save data at: {path}", GameLogger.LogLevel.System);
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                GameLogger.Log($"[StorageManagement] Failed to save data with exception: {e.Message}", GameLogger.LogLevel.Exception);
                return false;
            }
        }

        public static T Load<T>(string path)
        {
            return (T)Load(path);
        }

        public static object Load(string path)
        {
            path = Path.Combine(dataPath, path);

            if (!File.Exists(path))
            {
                GameLogger.Log($"[StorageManagement] Failed to load data, file missing at: {path}", GameLogger.LogLevel.Error);
                return null;
            }

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        var data = JsonConvert.DeserializeObject(json);

                        if(data == null)
                        {
                            throw new NullReferenceException("Deserialization failure");
                        }

                        return data;
                    }
                }
            }
            catch(Exception e)
            {
                GameLogger.Log($"[StorageManagement] Failed to load data with exception: {e.Message}", GameLogger.LogLevel.Exception);
                return null;
            }
        }
    }
}
