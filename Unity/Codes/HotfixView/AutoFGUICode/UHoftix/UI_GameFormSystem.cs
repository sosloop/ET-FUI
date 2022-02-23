/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
	public class UI_GameFormAwakeSystem : AwakeSystem<UI_GameForm>
	{
		public override void Awake(UI_GameForm self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.uiTransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class UI_GameFormAwakeSystem1 : AwakeSystem<UI_GameForm,GObject>
    {
        public override void Awake(UI_GameForm self,GObject transform)
        {
            self.GObject = transform;
            self.uiTransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class UI_GameFormDestroySystem : DestroySystem<UI_GameForm>
    {
        public override void Destroy(UI_GameForm self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.uiTransform = null;
			self.m_LoginBtn = null;
        }
    }
}