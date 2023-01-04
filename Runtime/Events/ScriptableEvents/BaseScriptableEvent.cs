using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    // references
    // https://github.com/chark/scriptable-events/tree/master/Packages/com.chark.scriptable-events/Runtime

    public abstract class BaseScriptableEvent<T> : BaseScriptableEvent
    {
        private readonly HashSet<Action<T>> m_listeners = new HashSet<Action<T>>();

        public int listenerCount => m_listeners.Count;

        private void OnDisable()
        {
            RemoveListeners();
        }

        public void Raise(T arg)
        {
            foreach(var listener in m_listeners)
            {
                listener.Invoke(arg);
            }
        }

        public void AddListener(IScriptableEventListener<T> listener)
        {
            AddListener(listener.OnRaised);
        }

        public void AddListener(Action<T> listener)
        {
            if (listener == null)
                throw new ArgumentNullException($"{nameof(listener)} cannot be null");

            m_listeners.Add(listener);
        }

        public void RemoveListener(IScriptableEventListener<T> removeListener)
        {
            RemoveListener(removeListener.OnRaised);
        }

        public void RemoveListener(Action<T> removeListener)
        {
            m_listeners.Remove(removeListener);
        }

        public void RemoveListeners()
        {
            m_listeners.Clear();
        }
    }

    public abstract class BaseScriptableEvent : ScriptableObject
    {
        
    }
}
