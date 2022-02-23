using System;

namespace ET
{
    [ObjectSystem]
    public class FGUIEventComponentAwakeSystem : AwakeSystem<FGUIEventComponent>
    {
        public override void Awake(FGUIEventComponent self)
        {
            FGUIEventComponent.Instance = self;
            self.Awake();
        }
    }
    
    [ObjectSystem]
    public class FGUIEventComponentDestroySystem : DestroySystem<FGUIEventComponent>
    {
        public override void Destroy(FGUIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            self.isClicked = false;
            FGUIEventComponent.Instance = null;
        }
    }
    
    public static class FGUIEventComponentSystem
    {
        public static void Awake(this FGUIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            foreach (Type v in Game.EventSystem.GetTypes(typeof (AFGUIEventAttribute)))
            {
                AFGUIEventAttribute attr = v.GetCustomAttributes(typeof (AFGUIEventAttribute), false)[0] as AFGUIEventAttribute;
                self.UIEventHandlers.Add(attr.WindowID, Activator.CreateInstance(v) as IAFGUIEventHandler);
            }
        }
        
        public static IAFGUIEventHandler GetUIEventHandler(this FGUIEventComponent self,string windowID)
        {
            if (self.UIEventHandlers.TryGetValue(windowID, out IAFGUIEventHandler handler))
            {
                return handler;
            }
            Log.Error($"windowId : {windowID} is not have any uiEvent");
            return null;
        }

        public static void SetUIClicked(this FGUIEventComponent self,bool isClicked)
        {
            self.isClicked = isClicked;
        }

    }
}