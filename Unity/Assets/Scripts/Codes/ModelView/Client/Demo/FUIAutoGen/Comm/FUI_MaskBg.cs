/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Comm
{
	public partial class FUI_MaskBg: GComponent
	{
		public GGraph Mask;
		public const string URL = "ui://sgg4y63lzcih1";

		public static FUI_MaskBg CreateInstance()
		{
			return (FUI_MaskBg)UIPackage.CreateObject("Comm", "MaskBg");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Mask = (GGraph)GetChildAt(0);
		}
	}
}
