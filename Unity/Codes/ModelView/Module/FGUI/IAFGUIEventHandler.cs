namespace ET
{
    public interface IAFGUIEventHandler
    {
        /// <summary>
        /// UI实体加载后,初始化窗口数据
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        void OnInitWindowCoreData(FGUIBaseWindow uiBaseWindow);
        
        /// <summary>
        /// UI实体加载后，初始化业务逻辑数据
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        void OnInitComponent(FGUIBaseWindow uiBaseWindow);
        
        /// <summary>
        /// 注册UI业务逻辑事件
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        void OnRegisterUIEvent(FGUIBaseWindow uiBaseWindow);

        /// <summary>
        /// 打开UI窗口的业务逻辑
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        /// <param name="contextData"></param>
        void OnShowWindow(FGUIBaseWindow uiBaseWindow, Entity contextData = null);
        
        /// <summary>
        /// 隐藏UI窗口的业务逻辑
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        void OnHideWindow(FGUIBaseWindow uiBaseWindow);

        /// <summary>
        /// 完全关闭销毁UI窗口之前的业务逻辑，用于完全释放UI相关对象
        /// </summary>
        /// <param name="uiBaseWindow"></param>
        void BeforeUnload(FGUIBaseWindow uiBaseWindow);
    }
}