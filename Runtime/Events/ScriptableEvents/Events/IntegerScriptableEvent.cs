using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class IntegerUnityEvent : UnityEvent<int> { }

    [CreateAssetMenu(
        fileName = "New IntegerScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Integer Scriptable Event")]
    public class IntegerScriptableEvent : BaseScriptableEvent<int> { }
}
