using System;
using ET.EventType;
using UGFExtensions;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterCreateLoginSceneEvent_ShowLoginUI:AEvent<AfterCreateLoginScene>
    {
        protected override async ETTask Run(Scene scene, AfterCreateLoginScene a)
        {
            try
            {
                FUIComponent fuiComponent = scene.GetComponent<FUIComponent>();
                // 加载 Packages
                await FUIPackageLoader.LoadPackagesAsync(fuiComponent);

                await fuiComponent.ShowPanelAsync(PanelId.LoginPanel);
                
                GameEntrys.BuiltinData.CloseDlgUpdateResource();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            
        }
    }
}

