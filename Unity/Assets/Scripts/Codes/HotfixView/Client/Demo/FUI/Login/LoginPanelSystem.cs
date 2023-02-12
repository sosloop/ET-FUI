namespace ET.Client
{
	public static class LoginPanelSystem
	{
		public static void Awake(this LoginPanel self)
		{
			Log.Debug("LoginPanelSystem awake");
		}

		public static void RegisterUIEvent(this LoginPanel self)
		{
			self.FUILoginPanel.login.AddListnerAsync(self.Login);
		}

		public static void OnShow(this LoginPanel self, Entity contexData = null)
		{

		}

		public static void OnHide(this LoginPanel self)
		{

		}

		public static void BeforeUnload(this LoginPanel self)
		{

		}
		
		private static async ETTask Login(this LoginPanel self)
		{
			self.GetParent<FUIEntity>().ShowNetLoading();
			await LoginHelper.Login(self.ClientScene(), self.FUILoginPanel.account.text, self.FUILoginPanel.pwd.text);
		}
	}
}