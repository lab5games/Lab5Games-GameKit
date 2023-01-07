using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Lab5Games.UI
{
    // references:
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16
    public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public UnityEvent onTabEnter;
        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;
        public UnityEvent onTabReset;

        public event Action<TabButton> onPointerEnter;
        public event Action<TabButton> onPointerExit;
        public event Action<TabButton> onPointerClick;

        public virtual void Select()
        {
            onTabSelected?.Invoke();
        }

        public virtual void Deselect()
        {
            onTabDeselected?.Invoke();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            onPointerClick?.Invoke(this);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter?.Invoke(this);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            onPointerExit?.Invoke(this);
        }
    }
}
