using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }


    [CreateAssetMenu(
        fileName = "New BooleanScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Boolean Scriptable Event")]
    public class BooleanScriptableEvent : BaseScriptableEvent<bool> { }
}
