using ET.Client.Game;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class GamePanel: Entity, IAwake
	{
		private FUI_GamePanel _fuiGamePanel;

		public FUI_GamePanel FUIGamePanel
		{
			get => _fuiGamePanel ??= (FUI_GamePanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}
