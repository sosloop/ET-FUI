using System.Collections.Generic;

namespace ET
{
    public class FGUIEventComponent : Entity,IAwake,IDestroy
    {
        public static FGUIEventComponent Instance { get; set; }
        public readonly Dictionary<string, IAFGUIEventHandler> UIEventHandlers = new Dictionary<string, IAFGUIEventHandler>();
        public bool isClicked { get; set; }
    }
}