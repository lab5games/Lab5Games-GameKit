using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Void Event Listener")]
    public class VoidScriptableEventListener : BaseScriptableEventListener<Void, VoidScriptableEvent, VoidUnityEvent>
    {
    }
}
