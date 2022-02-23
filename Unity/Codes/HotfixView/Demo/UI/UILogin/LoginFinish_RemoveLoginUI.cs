

namespace ET
{
	public class LoginFinish_RemoveLoginUI: AEvent<EventType.LoginFinish>
	{
		protected override async ETTask Run(EventType.LoginFinish args)
		{
			 args.ZoneScene.GetComponent<FGUIComponent>().CloseWindow(UI_LoginForm.UIResName);
			 await ETTask.CompletedTask;
		}
	}
}
