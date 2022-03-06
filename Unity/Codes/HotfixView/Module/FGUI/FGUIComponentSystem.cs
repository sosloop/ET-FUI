using System;
using System.Collections.Generic;
using FairyGUI;

namespace ET
{
    
    [ObjectSystem]
    public class FGUIComponentAwakeSystem : AwakeSystem<FGUIComponent>
    {
        public override void Awake(FGUIComponent self)
        {
            self.Awake();
        }
    }    
    
    [ObjectSystem]
    public class FGUIComponentUpdateSystem : UpdateSystem<FGUIComponent>
    {
        public override void Update(FGUIComponent self)
        {
            self.Update();
        }
    }
    
    [ObjectSystem]
    public class FGUIComponentDestroySystem : DestroySystem<FGUIComponent>
    {
        public override void Destroy(FGUIComponent self)
        {
            self.Destroy();
        }
    }
    
    public static class FGUIComponentSystem
    {

        public static void Update(this FGUIComponent self)
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.R))
            {
                CodeLoader.Instance.LoadLogic();
                Game.EventSystem.Add(CodeLoader.Instance.GetTypes());
                Game.EventSystem.Load();
                Log.Debug("hot reload success!");
            }
        }

        public static void Awake(this FGUIComponent self)
        {
            if (null != self.AllWindowsDic)
            {
                self.AllWindowsDic.Clear();
            }
            if (null != self.VisibleWindowsDic)
            {
                self.VisibleWindowsDic.Clear();
            }
        }

        public static void Destroy(this FGUIComponent self)
        {
            self.ClearAllWindow();
        }
        //////////////////// 同步显示界面 ////////////////////
        private static FGUIBaseWindow GetUIBaseWindow(this FGUIComponent self,string id)
        {
            if (self.AllWindowsDic.ContainsKey(id))
            {
                return self.AllWindowsDic[id];
            }
            return null;
        }
        
        private static void RealShowWindow(this FGUIComponent self, FGUIBaseWindow baseWindow, string id, ShowWindowData showData = null)
        {
            Entity contextData = showData == null ? null : showData.contextData;
            FGUIEventComponent.Instance.GetUIEventHandler(id).OnShowWindow(baseWindow,contextData);

            self.VisibleWindowsDic[id] = baseWindow;
            Log.Debug("<color=magenta>### current Navigation window </color>" + baseWindow.WindowID);
        }
        //////////////////// 异步显示界面 ////////////////////

        public static async ETTask ShowWindowAsync(this FGUIComponent self, string package, string res, ShowWindowData showData = null)
        {
            try
            {
                if (self.LoadingWindows.Contains(res))
                {
                    Log.Warning($"{res} is loading....");
                    return;
                }
                FGUIBaseWindow baseWindow = await self.ShowBaseWindowAsync(package,res, showData);
                if (null != baseWindow)
                {
                    self.RealShowWindow(baseWindow,res, showData);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        private static async ETTask<FGUIBaseWindow> ShowBaseWindowAsync(this FGUIComponent self, string package, string res, ShowWindowData showData = null)
        {
            FGUIBaseWindow baseWindow = self.GetUIBaseWindow(res);
            if (null == baseWindow)
            {
                baseWindow          = self.AddChild<FGUIBaseWindow>();
                baseWindow.PackageID = package;
                baseWindow.WindowID = res;
                await self.LoadBaseWindowsAsync(baseWindow);
            }
            if (!baseWindow.IsPreLoad)
            {
                await self.LoadBaseWindowsAsync(baseWindow);
            }
            return baseWindow;
        }

        private static async ETTask LoadBaseWindowsAsync(this FGUIComponent self, FGUIBaseWindow baseWindow)
        {
            self.LoadingWindows.Add(baseWindow.WindowID);
            
            await FUIPackageComponent.Instance.AddPackageAsync(baseWindow.PackageID);
            baseWindow.UIPrefabGameObject = await FUIPackageComponent.Instance.CreateGo(baseWindow.PackageID,baseWindow.WindowID);
            baseWindow.SetRoot(GRoot.inst);
            
            FGUIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitWindowCoreData(baseWindow);
            FGUIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnInitComponent(baseWindow);
            FGUIEventComponent.Instance.GetUIEventHandler(baseWindow.WindowID).OnRegisterUIEvent(baseWindow);
            
            self.AllWindowsDic[baseWindow.WindowID] = baseWindow;
            
            self.LoadingWindows.Remove(baseWindow.WindowID);
            
        }

        //////////////////// 关闭界面 ////////////////////

        public static void ClearAllWindow(this FGUIComponent self)
        {
            if (self.AllWindowsDic == null)
            {
                return;
            }
            foreach (KeyValuePair<string, FGUIBaseWindow> window in self.AllWindowsDic)
            {
                FGUIBaseWindow baseWindow = window.Value;
                if (baseWindow == null|| baseWindow.IsDisposed)
                {
                    continue;
                }
                self.UnLoadWindow(baseWindow.WindowID);
                baseWindow?.Dispose();
            }
            self.AllWindowsDic.Clear();
            self.VisibleWindowsDic.Clear();
            self.LoadingWindows.Clear();
        }
        
        public static void CloseWindow(this FGUIComponent self,string windowId)
        {
            if (!self.VisibleWindowsDic.ContainsKey(windowId))
            {
                return;
            }
            self.UnLoadWindow(windowId);
            Log.Debug($"<color=magenta>## close window without {windowId} ##</color>");
        }
        
        public static void UnLoadWindow(this FGUIComponent self,string id)
        {
            FGUIBaseWindow baseWindow = self.GetUIBaseWindow(id);
            if (null == baseWindow)
            {
                Log.Error($"FGUIBaseWindow WindowId {id} is null!!!");
                return;
            }
            FGUIEventComponent.Instance.GetUIEventHandler(id).BeforeUnload(baseWindow);
            if(baseWindow.IsPreLoad)
            {
                baseWindow.UIPrefabGameObject = null;
            }
            
            self.AllWindowsDic.Remove(id);
            self.VisibleWindowsDic.Remove(id);
            baseWindow?.Dispose();
        }
        
        private static bool CheckDirectlyHide(this FGUIComponent self,string id)
        {
            if (!self.VisibleWindowsDic.ContainsKey(id))
            {
                return false;
            }

            FGUIBaseWindow baseWindow = self.VisibleWindowsDic[id];
            if (baseWindow != null && !baseWindow.IsDisposed )
            {
                baseWindow.UIPrefabGameObject.visible = false;
                FGUIEventComponent.Instance.GetUIEventHandler(id).OnHideWindow(baseWindow);
            }
            self.VisibleWindowsDic.Remove(id);
            return true;
        }

    }
}