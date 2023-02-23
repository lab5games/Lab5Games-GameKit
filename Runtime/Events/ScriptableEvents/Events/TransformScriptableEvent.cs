using Lab5Games.Events.Scriptable;
using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events
{
    [System.Serializable]
    public class TransformUnityEvent : UnityEvent<Transform> { }

    [CreateAssetMenu(
        fileName ="New Transform Scriptable Event",
        menuName ="Scriptable Events/Transform Event")]
    public class TransformScriptableEvent : BaseScriptableEvent<Transform>
    {
    }
}
