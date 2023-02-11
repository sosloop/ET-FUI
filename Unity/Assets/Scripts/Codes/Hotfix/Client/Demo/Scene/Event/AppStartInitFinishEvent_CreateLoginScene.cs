using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AppStartInitFinishEvent_CreateLoginScene:AEvent<AppStartInitFinish>
    {
        protected override async ETTask Run(Scene scene, AppStartInitFinish a)
        {
            CurrentScenesComponent currentScenesComponent = scene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose();

            Scene loginScene =
                    SceneFactory.CreateCurrentScene(IdGenerater.Instance.GenerateId(), scene.Zone, "loginScene", currentScenesComponent);

            await EventSystem.Instance.PublishAsync(loginScene,new AfterCreateLoginScene());
        }
    }
}

