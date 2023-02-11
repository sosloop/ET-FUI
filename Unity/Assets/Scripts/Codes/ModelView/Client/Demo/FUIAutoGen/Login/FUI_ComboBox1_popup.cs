/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_ComboBox1_popup: GComponent
	{
		public GList list;
		public const string URL = "ui://9yz3lpikzcih6";

		public static FUI_ComboBox1_popup CreateInstance()
		{
			return (FUI_ComboBox1_popup)UIPackage.CreateObject("Login", "ComboBox1_popup");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			list = (GList)GetChildAt(1);
		}
	}
}
