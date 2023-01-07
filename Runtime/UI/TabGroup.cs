using System.Collections.Generic;
using UnityEngine;

namespace Lab5Games.UI
{
    // references:
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16
    
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] protected TabButton[] m_DefaultButtons;

        protected List<TabButton> m_TabButtons;

        protected TabButton m_SelectedButton = null;

        public void Subscribe(TabButton button)
        {
            if (m_TabButtons == null)
                m_TabButtons = new List<TabButton>();

            button.onPointerClick += OnTabSelected;
            button.onPointerEnter += OnTabEnter;
            button.onPointerExit += OnTabExit;

            m_TabButtons.Add(button);
        }

        public virtual void OnTabEnter(TabButton button)
        {
            if (!enabled) 
                return;

            ResetTabs();

            if (m_SelectedButton == null || button != m_SelectedButton)
            {
                button.onTabEnter?.Invoke();
            }
        }

        public virtual void OnTabExit(TabButton button)
        {
            if (!enabled) 
                return;

            ResetTabs();
        }

        public virtual void OnTabSelected(TabButton button)
        {
            if (!enabled)
                return;

            if (m_SelectedButton != null)
            {
                if (m_SelectedButton == button)
                    return;

                m_SelectedButton.Deselect();
            }

            m_SelectedButton = button;
            m_SelectedButton.Select();

            ResetTabs();
        }

        public virtual void ResetTabs()
        {
            if(m_TabButtons != null)
            {
                foreach(TabButton button in m_TabButtons)
                {
                    button.onTabReset?.Invoke();
                }
            }
        }

        protected virtual void Awake()
        {
            foreach(var btn in m_DefaultButtons)
            {
                Subscribe(btn);
            }
        }

        protected virtual void OnEnable()
        {
            ResetTabs();
        }
    }
}
