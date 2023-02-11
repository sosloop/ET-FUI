namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AfterCreateClientScene_AddComponent: AEvent<EventType.AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateClientScene args)
        {
            scene.AddComponent<FUIEventComponent>();
            scene.AddComponent<FUIComponent>();
            await ETTask.CompletedTask;
        }
    }
}