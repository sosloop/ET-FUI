/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_MaskBg : GComponent
    {
        public GGraph Mask;
        public const string URL = "ui://jzlp9kcg98vk2";

        public static FUI_MaskBg CreateInstance()
        {
            return (FUI_MaskBg)UIPackage.CreateObject("BootPack", "MaskBg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Mask = (GGraph)GetChildAt(0);
        }
    }
}