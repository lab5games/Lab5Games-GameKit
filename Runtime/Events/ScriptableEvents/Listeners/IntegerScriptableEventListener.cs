using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Integer ScriptableEventListener")]
    public class IntegerScriptableEventListener : BaseScriptableEventListener<int, IntegerScriptableEvent, IntegerUnityEvent>
    {
    }
}
