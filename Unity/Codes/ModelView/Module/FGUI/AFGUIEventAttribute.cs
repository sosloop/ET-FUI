using System;

namespace ET
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AFGUIEventAttribute : BaseAttribute
    {
        public string WindowID
        {
            get;
        }

        public AFGUIEventAttribute(string windowID)
        {
            this.WindowID = windowID;
        }
    }
}