/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_NetLoadingUI : GComponent
    {
        public GTextField title;
        public FUI_GlobalModalWaiting wait;
        public const string URL = "ui://jzlp9kcg98vk7";

        public static FUI_NetLoadingUI CreateInstance()
        {
            return (FUI_NetLoadingUI)UIPackage.CreateObject("BootPack", "NetLoadingUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField)GetChildAt(1);
            wait = (FUI_GlobalModalWaiting)GetChildAt(2);
        }
    }
}