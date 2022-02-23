using System;
using System.Net;

using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static class UILoginComponentSystem
	{
		public static void RegisterUIEvent(this UILoginComponent self)
		{
			self.View.EGButton_LoginBtn.AddListener(() =>
			{
				self.OnLogin();
			});
		}
		
		public static void ShowWindow(this UILoginComponent self,Entity contextData = null)
		{
		}

		public static void OnLogin(this UILoginComponent self)
		{
			LoginHelper.Login(
				self.DomainScene(), 
				ConstValue.LoginAddress, 
				self.View.EUI_InputText_Account.EGTextInput_IText.text, 
				self.View.EUI_InputText_PassWord.EGTextInput_IText.text).Coroutine();
		}
	}
}
