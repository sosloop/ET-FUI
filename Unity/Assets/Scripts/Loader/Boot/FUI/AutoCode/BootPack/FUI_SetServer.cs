/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.BootPack
{
    public partial class FUI_SetServer : GComponent
    {
        public GTextInput server;
        public GButton set;
        public const string URL = "ui://jzlp9kcgtmmlc";

        public static FUI_SetServer CreateInstance()
        {
            return (FUI_SetServer)UIPackage.CreateObject("BootPack", "SetServer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            server = (GTextInput)GetChildAt(1);
            set = (GButton)GetChildAt(2);
        }
    }
}