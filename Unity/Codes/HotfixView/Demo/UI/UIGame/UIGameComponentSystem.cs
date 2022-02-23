namespace ET
{
    public static class UIGameComponentSystem
    {
        public static void RegisterUIEvent(this UIGameComponent self)
        {
            self.View.EGButton_LoginBtn.AddListener(() =>
            {
                Log.Info("退出场景");
            });
        }
		
        public static void ShowWindow(this UIGameComponent self,Entity contextData = null)
        {
        }
    }
}