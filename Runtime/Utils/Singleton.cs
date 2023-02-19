using UnityEngine;

namespace Lab5Games
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T m_Instance = null;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new T();
                }

                return m_Instance;
            }
        }
    }


    public abstract class ComponentSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public virtual bool IsPersistent { get; }

        private static T m_Instance = null;

        public static T Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();


                    if(m_Instance != null)
                    {
                        var method = typeof(T).GetMethod("OnCreate");

                        if(method != null)
                        {
                            method.Invoke(m_Instance, null);
                        }
                    }
                }

                return m_Instance;
            }
        }

        protected virtual void Awake()
        {
            if (Instance == null)
                m_Instance = this as T;

            if(m_Instance != this)
            {
                GameLogger.Log($"[ComponentSingleton] There should never be more than one {typeof(T).Name} instance at the same time", GameLogger.LogLevel.Warning, this);

                enabled = false;
                return;
            }
            
            if (IsPersistent) DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            m_Instance = null;
            GameLogger.Log($"[ComponentSingleton] {typeof(T).Name} instance has been destroyed", GameLogger.LogLevel.System);
        }
    }
}
