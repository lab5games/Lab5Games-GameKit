using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    public abstract class BaseScriptableEventListener<T, E, U> : BaseScriptableEventListener, IScriptableEventListener<T> 
        where E : BaseScriptableEvent<T> 
        where U : UnityEvent<T>
    {
        [SerializeField] private E Event;
        [SerializeField] private U onRaise;

        void OnEnable()
        {
            Event?.AddListener(this);
        }

        void OnDisable()
        {
            Event?.RemoveListener(this);
        }

        public void OnRaise(T arg)
        {
            onRaise?.Invoke(arg);
        }
    }

    public abstract class BaseScriptableEventListener : MonoBehaviour
    {
    }

    public interface IScriptableEventListener<T>
    {
        void OnRaise(T arg);
    }
}
