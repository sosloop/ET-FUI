/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
	public class UI_HallFormAwakeSystem : AwakeSystem<UI_HallForm>
	{
		public override void Awake(UI_HallForm self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.uiTransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class UI_HallFormAwakeSystem1 : AwakeSystem<UI_HallForm,GObject>
    {
        public override void Awake(UI_HallForm self,GObject transform)
        {
            self.GObject = transform;
            self.uiTransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class UI_HallFormDestroySystem : DestroySystem<UI_HallForm>
    {
        public override void Destroy(UI_HallForm self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.uiTransform = null;
			self.m_LoginBtn = null;
        }
    }
}