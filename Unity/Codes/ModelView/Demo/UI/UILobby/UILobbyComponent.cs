
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public class UILobbyComponent : Entity, IAwake
	{
		public UI_HallForm View { get => this.Parent.GetComponent<UI_HallForm>();} 
	}
}
