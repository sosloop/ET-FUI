/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_GlobalModalWaiting : GComponent
    {
        public Transition t0;
        public const string URL = "ui://jzlp9kcg98vk9";

        public static FUI_GlobalModalWaiting CreateInstance()
        {
            return (FUI_GlobalModalWaiting)UIPackage.CreateObject("BootPack", "GlobalModalWaiting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
        }
    }
}