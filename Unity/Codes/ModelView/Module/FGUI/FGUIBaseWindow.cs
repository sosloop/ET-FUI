using FairyGUI;

namespace ET
{
    public class FGUIBaseWindow : Entity,IAwake
    {
        public bool IsPreLoad
        {
            get
            {
                return this.UIPrefabGameObject != null ;
            }
        }
        
        public GComponent uiTransform
        {
            get
            {
                if (null != this.UIPrefabGameObject)
                {
                    return this.UIPrefabGameObject.asCom;
                }
                return null;
            }
        }
        
        public string WindowID
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_windowID))
                {
                    Log.Error("window id is empty");
                }
                return m_windowID;
            }
            set { m_windowID = value; }
        }
        
        public string PackageID
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_packageID))
                {
                    Log.Error("packageID id is empty");
                }
                return m_packageID;
            }
            set { m_packageID = value; }
        }
        
        public string PreWindowID
        {
            get { return m_preWindowID; }
            set { m_preWindowID = value; }
        }
        
        public string m_preWindowID = string.Empty;
        public string m_windowID = string.Empty;
        public string m_packageID = string.Empty;
        
        public GObject UIPrefabGameObject = null;
        public WindowCoreData WindowData = null;
    }
}