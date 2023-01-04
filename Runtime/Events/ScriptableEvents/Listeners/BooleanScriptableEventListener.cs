using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Boolean ScriptableEventListener")]
    public class BooleanScriptableEventListener : BaseScriptableEventListener<bool, BooleanScriptableEvent, BooleanUnityEvent>
    {
    }
}
