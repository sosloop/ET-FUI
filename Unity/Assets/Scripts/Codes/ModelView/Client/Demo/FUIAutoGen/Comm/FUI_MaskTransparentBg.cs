/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Comm
{
	public partial class FUI_MaskTransparentBg: GComponent
	{
		public GGraph Mask;
		public const string URL = "ui://sgg4y63lzcih2";

		public static FUI_MaskTransparentBg CreateInstance()
		{
			return (FUI_MaskTransparentBg)UIPackage.CreateObject("Comm", "MaskTransparentBg");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Mask = (GGraph)GetChildAt(0);
		}
	}
}
