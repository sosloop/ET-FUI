/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.UModel
{
    public partial class UI_UpdateForm : GComponent
    {
        public GProgressBar m_Progress;
        public GTextField m_Tip;
        public const string URL = "ui://fv3hjfnr6mfb0";

        public static UI_UpdateForm CreateInstance()
        {
            return (UI_UpdateForm)UIPackage.CreateObject("UModel", "UpdateForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_Progress = (GProgressBar)GetChildAt(2);
            m_Tip = (GTextField)GetChildAt(3);
        }
    }
}