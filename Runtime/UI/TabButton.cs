using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Lab5Games.UI
{
    // references:
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16
    public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] TabGroup tabGroup;

        public UnityEvent onTabEnter;
        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;
        public UnityEvent onTabReset;

        public virtual void Select()
        {
            onTabSelected?.Invoke();
        }

        public virtual void Deselect()
        {
            onTabDeselected?.Invoke();
        }

        private void Start()
        {
            if (tabGroup == null)
                tabGroup = GetComponentInParent<TabGroup>();

            tabGroup.Subscribe(this);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.OnTabSelected(this);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.OnTabEnter(this);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.OnTabExit(this);
        }
    }
}
