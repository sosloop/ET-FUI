using FairyGUI;

namespace ET.Client
{
    [ObjectSystem]
    public class FUIEntityAwakeSystem : AwakeSystem<FUIEntity>
    {
        protected override void Awake(FUIEntity self)
        {
            self.PanelCoreData = self.AddChild<PanelCoreData>();
        }
    }

    [ObjectSystem]
    public class FUIEntityDestroySystem: DestroySystem<FUIEntity>
    {
        protected override void Destroy(FUIEntity self)
        {
            self.GComponent?.Dispose();
            self.NetLoading?.Dispose();
            self.PanelCoreData?.Dispose();

            self.GComponent = null;
            self.NetLoading = null;
            self.PanelCoreData = null;
            
            self.PanelId = PanelId.Invalid;
        }
    }

    public static class FUIEntitySystem
    {
        public static void SetRoot(this FUIEntity self, GComponent rootGComponent)
        {
            if(self.GComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} GComponent is null!!!");
                return;
            }
            if(rootGComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} rootGComponent is null!!!");
                return;
            }
            rootGComponent.AddChild(self.GComponent);
        }
    }
}