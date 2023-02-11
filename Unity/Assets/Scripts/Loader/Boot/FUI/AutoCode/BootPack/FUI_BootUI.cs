/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_BootUI : GComponent
    {
        public GTextField title;
        public GProgressBar progress;
        public GTextField info;
        public const string URL = "ui://jzlp9kcg98vk0";

        public static FUI_BootUI CreateInstance()
        {
            return (FUI_BootUI)UIPackage.CreateObject("BootPack", "BootUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField)GetChildAt(1);
            progress = (GProgressBar)GetChildAt(2);
            info = (GTextField)GetChildAt(3);
        }
    }
}