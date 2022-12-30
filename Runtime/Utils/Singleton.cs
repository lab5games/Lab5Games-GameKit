using System;
using UnityEngine;

namespace Lab5Games
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T m_instance = null;

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new T();
                }

                return m_instance;
            }
        }

        public virtual void Destroy()
        {
            m_instance = null;
            GameLogger.Log($"[Singleton] {typeof(T).Name} instance has been destroyed", GameLogger.LogLevel.System);
        }
    }


    public abstract class ComponentSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public virtual bool IsPersistent { get; }

        private static T _instance = null;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
                _instance = this as T;

            if(_instance != this)
            {
                GameLogger.Log($"[ComponentSingleton] There should never be more than one {typeof(T).Name} instance at the same time", GameLogger.LogLevel.Warning, this);

                enabled = false;
                return;
            }
            
            if (IsPersistent) DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            _instance = null;
            GameLogger.Log($"[ComponentSingleton] {typeof(T).Name} instance has been destroyed", GameLogger.LogLevel.System);
        }
    }
}
