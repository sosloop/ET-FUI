/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Game
{
	public partial class FUI_GamePanel: GComponent
	{
		public GButton transmit1;
		public GButton transmit2;
		public const string URL = "ui://fikv3jt4dnpj0";

		public static FUI_GamePanel CreateInstance()
		{
			return (FUI_GamePanel)UIPackage.CreateObject("Game", "GamePanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			transmit1 = (GButton)GetChildAt(0);
			transmit2 = (GButton)GetChildAt(1);
		}
	}
}
