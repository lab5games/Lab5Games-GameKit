using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject> { }

    [CreateAssetMenu(
        fileName ="New GameObject Scriptable Event",
        menuName ="Scriptable Events/GameObject Event")]
    public class GameObjectScriptableEvent : BaseScriptableEvent<GameObject>
    {
    }
}
