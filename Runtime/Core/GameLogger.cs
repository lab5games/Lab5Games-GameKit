
namespace Lab5Games
{
    public static class GameLogger 
    {
        public enum LogLevel
        {
            Log,
            Warning,
            Error,
            Exception,
            Assert,

            System,
            Network,
            Gameplay
        }

        public delegate void LogDelegate(string msg, string level, UnityEngine.Object context);

        public static LogDelegate onLog;

        static GameLogger()
        {
            onLog = new LogDelegate(PrintToConsole);
        }

        public static void Log(object obj, LogLevel level, UnityEngine.Object context = null)
        {
            Log(obj.ToString(), level, context);
        }

        public static void Log(string msg, LogLevel level, UnityEngine.Object context = null)
        {
            Log(msg, level.ToString(), context);
        }

        public static void Log(string msg, string level, UnityEngine.Object context = null)
        {
            onLog(msg, level, context);
        }

        public static void PrintToConsole(string msg, string level, UnityEngine.Object context)
        {
            UnityEngine.Debug.Log(msg + "\nCPAPI:{\"cmd\":\"Filter\", \"name\":\"" + level + "\"}", context);
        }

        public static void Watch(string displayName, string watchValue)
        {
            UnityEngine.Debug.Log(displayName + " : " + watchValue + "\nCPAPI:{\"cmd\":\"Watch\", \"name\":\"" + displayName + "\"}");
        }
    }
}
