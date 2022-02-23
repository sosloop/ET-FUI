using System;
using System.Net;

using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public class UILoginComponent: Entity, IAwake
	{
		public UI_LoginForm View { get => this.Parent.GetComponent<UI_LoginForm>();} 
	}
}
