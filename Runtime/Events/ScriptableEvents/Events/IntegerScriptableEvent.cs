using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class IntegerUnityEvent : UnityEvent<int> { }

    [CreateAssetMenu(
        fileName = "New Integer Scriptable Event",
        menuName = "Scriptable Events/Integer Event")]
    public class IntegerScriptableEvent : BaseScriptableEvent<int> { }
}
