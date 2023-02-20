using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }


    [CreateAssetMenu(
        fileName = "New Boolean Scriptable Event",
        menuName = "Scriptable Events/Boolean Event")]
    public class BooleanScriptableEvent : BaseScriptableEvent<bool> { }
}
