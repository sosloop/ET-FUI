

using UGFExtensions;

namespace ET
{
	public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			// await ETTask.CompletedTask;
			await args.ZoneScene.GetComponent<FGUIComponent>().ShowWindowAsync(UI_LoginForm.UIPackageName,UI_LoginForm.UIResName);
			GameEntry.BuiltinData.UpdateResourceForm.Dispose();
		}
	}
}
