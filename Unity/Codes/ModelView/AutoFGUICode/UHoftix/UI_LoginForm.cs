/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class UI_LoginForm : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHoftix";
        public const string UIResName = "LoginForm";
        public const string URL = "ui://fnfxb0keo9870";

        private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }

        private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static UI_LoginForm CreateInstance(Entity domain)
        {
            return domain.AddChild<UI_LoginForm, GObject>(CreateGObject());
        }

        public static async ETTask<UI_LoginForm> CreateInstanceAsync(Entity domain)
        {
            ETTask<UI_LoginForm> tcs = ETTask<UI_LoginForm>.Create(true);
            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(domain.AddChild<UI_LoginForm, GObject>(go));
            });
            return await tcs;
        }

        public GObject GObject = null;
        public GComponent uiTransform = null;
        public UI_InputText m_Account = null;
        public UI_InputText m_PassWord = null;
        public GButton m_LoginBtn = null;

        public UI_InputText EUI_InputText_Account
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_Account == null )
                {
                    this.m_Account = this.AddChild<UI_InputText, GObject>(uiTransform.GetChildAt(5));
                }
                return this.m_Account;
            }
        }
        public UI_InputText EUI_InputText_PassWord
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_PassWord == null )
                {
                    this.m_PassWord = this.AddChild<UI_InputText, GObject>(uiTransform.GetChildAt(6));
                }
                return this.m_PassWord;
            }
        }
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
                    this.m_LoginBtn = (GButton)uiTransform.GetChildAt(7);
                }
                return this.m_LoginBtn;
            }
        }
    }
}