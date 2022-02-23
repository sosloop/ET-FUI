using System;
using FairyGUI;

namespace ET
{
    public static class FGUIHelp
    {
        
        public static void AddListenerAsync(this GButton gButton,Func<ETTask> action)
        {
            async ETTask clickActionAsync()
            {
                FGUIEventComponent.Instance.SetUIClicked(true);
                await action();
                FGUIEventComponent.Instance.SetUIClicked(false);
            }
            
            gButton.onClick.Set(() =>
            {
                if (FGUIEventComponent.Instance == null)
                {
                    return;
                }

                if (FGUIEventComponent.Instance.isClicked)
                {
                    return;
                }

                clickActionAsync().Coroutine();
            });
        }

        public static void AddListener(this GButton gButton, System.Action action)
        {
            gButton.onClick.Set(() =>
            {
                action();
            });
        }
        
        public static void AddListener(this GButton gButton, System.Action<int> action ,int id)
        {
            gButton.onClick.Set(() =>
            {
                action(id);
            });
        }
      


    }
}