using FairyGUI;

namespace ET
{

    [ObjectSystem]
    public class FGUIBaseWindowAwakeSystem : AwakeSystem<FGUIBaseWindow>
    {
        public override void Awake(FGUIBaseWindow self)
        {
            self.WindowData = self.AddChild<WindowCoreData>();
        }
    }
    
    public  static class FGUIBaseWindowSystem  
    {
        public static void SetRoot(this FGUIBaseWindow self, GComponent rootTransform)
        {
            if(self.uiTransform == null)
            {
                Log.Error($"fguibaseWindows {self.WindowID} fguiTransform is null!!!");
                return;
            }
            if(rootTransform == null)
            {
                Log.Error($"fguibaseWindows {self.WindowID} rootTransform is null!!!");
                return;
            }

            rootTransform.AddChild(self.uiTransform);
        }
    }
}