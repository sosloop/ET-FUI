/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class UI_HallForm : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHoftix";
        public const string UIResName = "HallForm";
        public const string URL = "ui://fnfxb0keo9873";

        private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }

        private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static UI_HallForm CreateInstance(Entity domain)
        {
            return domain.AddChild<UI_HallForm, GObject>(CreateGObject());
        }

        public static async ETTask<UI_HallForm> CreateInstanceAsync(Entity domain)
        {
            ETTask<UI_HallForm> tcs = ETTask<UI_HallForm>.Create(true);
            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(domain.AddChild<UI_HallForm, GObject>(go));
            });
            return await tcs;
        }

        public GObject GObject = null;
        public GComponent uiTransform = null;
        public GButton m_LoginBtn = null;

        public GButton EGButton_LoginBtn
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_LoginBtn == null )
                {
                    this.m_LoginBtn = (GButton)uiTransform.GetChildAt(2);
                }
                return this.m_LoginBtn;
            }
        }
    }
}