using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Integer Event Listener")]
    public class IntegerScriptableEventListener : BaseScriptableEventListener<int, IntegerScriptableEvent, IntegerUnityEvent>
    {
    }
}
