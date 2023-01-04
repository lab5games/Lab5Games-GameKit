using UnityEngine;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector3 ScriptableEventListener")]
    public class Vector3ScriptableEventLisener : BaseScriptableEventListener<Vector3, Vector3ScriptableEvent, Vector3UnityEvent>
    {
    }
}
