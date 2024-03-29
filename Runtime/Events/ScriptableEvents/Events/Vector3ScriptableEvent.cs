﻿using UnityEngine;
using UnityEngine.Events;

namespace Lab5Games.Events.Scriptable
{
    [System.Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }

    [CreateAssetMenu(
        fileName = "New Vector3 Scriptable Event",
        menuName = "Scriptable Events/Vector3 Event")]
    public class Vector3ScriptableEvent : BaseScriptableEvent<Vector3> { }
}
