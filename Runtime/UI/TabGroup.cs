using System.Collections.Generic;
using UnityEngine;

namespace Lab5Games.UI
{
    // references:
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16

    [AddComponentMenu(
        UIConstants.MenuNameToolkit + "/Tab Group")]
    public class TabGroup : MonoBehaviour
    {
        protected List<TabButton> tabButtons;
        protected TabButton selectedButton = null;

        public void Subscribe(TabButton button)
        {
            if (tabButtons == null)
                tabButtons = new List<TabButton>();

            tabButtons.Add(button);
        }


        public virtual void OnTabEnter(TabButton button)
        {
            if (!enabled) 
                return;

            ResetTabs();

            if (selectedButton == null || button != selectedButton)
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

            if (selectedButton != null)
            {
                if (selectedButton == button)
                    return;

                selectedButton.Deselect();
            }

            selectedButton = button;
            selectedButton.Select();

            ResetTabs();
        }

        public virtual void ResetTabs()
        {
            if(tabButtons != null)
            {
                foreach(TabButton button in tabButtons)
                {
                    button.onTabReset?.Invoke();
                }
            }
        }

        protected virtual void OnEnable()
        {
            ResetTabs();
        }
    }
}
