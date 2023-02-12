namespace ET.Client
{
	[FriendOf(typeof(PanelCoreData))]
	[FriendOf(typeof(FUIEntity))]
	[FUIEvent(PanelId.GamePanel, "Game", "GamePanel")]
	public class GameEventHandler: IFUIEventHandler
	{
		public void OnInitPanelCoreData(FUIEntity fuiEntity)
		{
			fuiEntity.PanelCoreData.panelType = UIPanelType.Normal;
		}

		public void OnInitComponent(FUIEntity fuiEntity)
		{
			GamePanel panel = fuiEntity.AddComponent<GamePanel>();
			panel.Awake();
		}

		public void OnRegisterUIEvent(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<GamePanel>().RegisterUIEvent();
		}

		public void OnShow(FUIEntity fuiEntity, Entity contexData = null)
		{
			fuiEntity.GetComponent<GamePanel>().OnShow(contexData);
		}

		public void OnHide(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<GamePanel>().OnHide();
		}

		public void BeforeUnload(FUIEntity fuiEntity)
		{
			fuiEntity.GetComponent<GamePanel>().BeforeUnload();
		}
	}
}