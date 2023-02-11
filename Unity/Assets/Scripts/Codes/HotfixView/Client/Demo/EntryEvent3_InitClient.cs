using System;
using System.IO;

namespace ET.Client
{
    [Event(SceneType.Process)]
    public class EntryEvent3_InitClient: AEvent<ET.EventType.EntryEvent3>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.EntryEvent3 args)
        {
            // 加载配置
            Root.Instance.Scene.AddComponent<GlobalComponent>();
            Root.Instance.Scene.AddComponent<FsmDispatcherComponent>();

            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game");
            
            await EventSystem.Instance.PublishAsync(clientScene, new EventType.AppStartInitFinish());
        }
    }
}