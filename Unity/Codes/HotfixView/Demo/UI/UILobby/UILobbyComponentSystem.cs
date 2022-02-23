using UnityEngine;
using UnityEngine.UI;

namespace ET
{


    public static class UILobbyComponentSystem
    {
        public static void RegisterUIEvent(this UILobbyComponent self)
        {
            self.View.EGButton_LoginBtn.AddListener(() =>
            {
                self.EnterMap().Coroutine();
            });
        }
		
        public static void ShowWindow(this UILobbyComponent self,Entity contextData = null)
        {
        }
        public static async ETTask EnterMap(this UILobbyComponent self)
        {
            await EnterMapHelper.EnterMapAsync(self.ZoneScene());
            var fgui = self.DomainScene().GetComponent<FGUIComponent>();
            fgui.CloseWindow(UI_HallForm.UIResName);
            fgui.ShowWindowAsync(UI_GameForm.UIPackageName,UI_GameForm.UIResName).Coroutine();
        }
    }
}