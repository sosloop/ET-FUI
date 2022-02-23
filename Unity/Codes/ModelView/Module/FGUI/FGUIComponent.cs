using System.Collections.Generic;

namespace ET
{
    public class FGUIComponent : Entity,IAwake,IUpdate,IDestroy
    {
        public HashSet<string> LoadingWindows                = new HashSet<string>();
        public Dictionary<string, FGUIBaseWindow> AllWindowsDic     = new Dictionary<string, FGUIBaseWindow>();
        public Dictionary<string, FGUIBaseWindow> VisibleWindowsDic = new Dictionary<string, FGUIBaseWindow>();
    }
}