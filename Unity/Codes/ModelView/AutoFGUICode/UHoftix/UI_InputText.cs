/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
    public class UI_InputText : Entity,IAwake,IAwake<GObject>,IDestroy
    {
        public const string UIPackageName = "UHoftix";
        public const string UIResName = "InputText";
        public const string URL = "ui://fnfxb0keo9871";

        private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }

        private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static UI_InputText CreateInstance(Entity domain)
        {
            return domain.AddChild<UI_InputText, GObject>(CreateGObject());
        }

        public static async ETTask<UI_InputText> CreateInstanceAsync(Entity domain)
        {
            ETTask<UI_InputText> tcs = ETTask<UI_InputText>.Create(true);
            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(domain.AddChild<UI_InputText, GObject>(go));
            });
            return await tcs;
        }

        public GObject GObject = null;
        public GComponent uiTransform = null;
        public GTextInput m_IText = null;

        public GTextInput EGTextInput_IText
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_IText == null )
                {
                    this.m_IText = (GTextInput)uiTransform.GetChildAt(1);
                }
                return this.m_IText;
            }
        }
    }
}