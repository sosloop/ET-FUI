namespace ET.Client
{
	[FriendOf(typeof(PanelCoreData))]
	[FriendOf(typeof(FUIEntity))]
	[FUIEvent(PanelId.LoginPanel, "Login", "LoginPanel")]
	public class LoginEventHandler: IFUIEventHandler
	{
		public void OnInitPanelCoreData(FUIEntity fuiEntity)
		{
			fuiEntity.PanelCoreData.panelType = UIPanelType.Normal;
		}

		public void OnInitComponent(FUIEntity fuiEntity)
		{
			LoginPanel panel = fuiEntity.AddComponent<LoginPanel>();
			panel.Awake();
		}

		public void OnRegisterUIEvent(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<LoginPanel>().RegisterUIEvent();
		}

		public void OnShow(FUIEntity fuiEntity, Entity contexData = null)
		{
			fuiEntity.GetComponent<LoginPanel>().OnShow(contexData);
		}

		public void OnHide(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<LoginPanel>().OnHide();
		}

		public void BeforeUnload(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<LoginPanel>().BeforeUnload();
		}
	}
}