/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
	public class UI_InputTextAwakeSystem : AwakeSystem<UI_InputText>
	{
		public override void Awake(UI_InputText self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.uiTransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class UI_InputTextAwakeSystem1 : AwakeSystem<UI_InputText,GObject>
    {
        public override void Awake(UI_InputText self,GObject transform)
        {
            self.GObject = transform;
            self.uiTransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class UI_InputTextDestroySystem : DestroySystem<UI_InputText>
    {
        public override void Destroy(UI_InputText self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.uiTransform = null;
			self.m_IText = null;
        }
    }
}