/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_MaskTransparentBg : GComponent
    {
        public GGraph Mask;
        public const string URL = "ui://jzlp9kcg98vk4";

        public static FUI_MaskTransparentBg CreateInstance()
        {
            return (FUI_MaskTransparentBg)UIPackage.CreateObject("BootPack", "MaskTransparentBg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Mask = (GGraph)GetChildAt(0);
        }
    }
}