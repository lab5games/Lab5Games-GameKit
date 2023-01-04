using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Void ScriptableEventListener")]
    public class VoidScriptableEventListener : BaseScriptableEventListener<Void, VoidScriptableEvent, VoidUnityEvent>
    {
    }
}
