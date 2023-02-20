using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    public struct Void
    {
        public static readonly Void empty = new Void();
    }

    [System.Serializable]
    public class VoidUnityEvent : UnityEvent<Void> { }

    [CreateAssetMenu(
        fileName = "New Void Scriptable Event",
        menuName = "Scriptable Events/Void Event")]
    public class VoidScriptableEvent : BaseScriptableEvent<Void>
    {
        public void Raise() => Raise(Void.empty);
    }
}
