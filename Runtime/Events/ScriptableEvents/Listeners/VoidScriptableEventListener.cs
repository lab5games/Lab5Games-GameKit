using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [AddComponentMenu("Scriptable Events/Void Event Listener")]
    public class VoidScriptableEventListener : BaseScriptableEventListener<Void, VoidScriptableEvent, VoidUnityEvent>
    {
    }
}
