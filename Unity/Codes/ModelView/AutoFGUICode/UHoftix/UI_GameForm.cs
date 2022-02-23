/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class UI_GameForm : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHoftix";
        public const string UIResName = "GameForm";
        public const string URL = "ui://fnfxb0kepqy84";

        private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }

        private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static UI_GameForm CreateInstance(Entity domain)
        {
            return domain.AddChild<UI_GameForm, GObject>(CreateGObject());
        }

        public static async ETTask<UI_GameForm> CreateInstanceAsync(Entity domain)
        {
            ETTask<UI_GameForm> tcs = ETTask<UI_GameForm>.Create(true);
            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(domain.AddChild<UI_GameForm, GObject>(go));
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
                    this.m_LoginBtn = (GButton)uiTransform.GetChildAt(0);
                }
                return this.m_LoginBtn;
            }
        }
    }
}