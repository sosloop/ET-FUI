

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class EnterMapFinish_CreateGameUI: AEvent<EventType.EnterMapFinish>
    {
        protected override async ETTask Run(Scene scene, EventType.EnterMapFinish a)
        {
            await scene.CurrentScene().GetComponent<FUIComponent>().ShowPanelAsync(PanelId.GamePanel);
            await ETTask.CompletedTask;
        }
    }
}
