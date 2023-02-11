/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

namespace ET.Client
{
	public static class FUIPackageLoader
	{
		public static async ETTask LoadPackagesAsync(FUIComponent fuiComponent)
		{
			using (ListComponent<ETTask> tasks = ListComponent<ETTask>.Create())
			{
				tasks.Add(fuiComponent.AddPackageAsync("Login"));

				await ETTaskHelper.WaitAll(tasks);
			}

			LoginBinder.BindAll();
		}
	}
}
