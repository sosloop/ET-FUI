/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_LoginPanel: GComponent
	{
		public GTextInput account;
		public GTextInput pwd;
		public GComboBox servers;
		public GButton login;
		public const string URL = "ui://9yz3lpikzcih0";

		public static FUI_LoginPanel CreateInstance()
		{
			return (FUI_LoginPanel)UIPackage.CreateObject("Login", "LoginPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			account = (GTextInput)GetChildAt(4);
			pwd = (GTextInput)GetChildAt(5);
			servers = (GComboBox)GetChildAt(6);
			login = (GButton)GetChildAt(7);
		}
	}
}
