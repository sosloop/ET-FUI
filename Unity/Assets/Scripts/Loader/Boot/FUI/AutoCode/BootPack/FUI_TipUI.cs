/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_TipUI : GComponent
    {
        public Controller show;
        public GGraph bg;
        public GTextField title;
        public GTextField content;
        public GButton no;
        public GButton ok;
        public GButton yes;
        public const string URL = "ui://jzlp9kcg98vk5";

        public static FUI_TipUI CreateInstance()
        {
            return (FUI_TipUI)UIPackage.CreateObject("BootPack", "TipUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            bg = (GGraph)GetChildAt(1);
            title = (GTextField)GetChildAt(2);
            content = (GTextField)GetChildAt(3);
            no = (GButton)GetChildAt(4);
            ok = (GButton)GetChildAt(5);
            yes = (GButton)GetChildAt(6);
        }
    }
}