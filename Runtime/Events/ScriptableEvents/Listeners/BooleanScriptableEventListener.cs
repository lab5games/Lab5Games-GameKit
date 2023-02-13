using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Boolean Event Listener")]
    public class BooleanScriptableEventListener : BaseScriptableEventListener<bool, BooleanScriptableEvent, BooleanUnityEvent>
    {
    }
}
