/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
	public class UI_LoginFormAwakeSystem : AwakeSystem<UI_LoginForm>
	{
		public override void Awake(UI_LoginForm self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.uiTransform = (GComponent)self.GObject;
		}
	}

    [ObjectSystem]
    public class UI_LoginFormAwakeSystem1 : AwakeSystem<UI_LoginForm,GObject>
    {
        public override void Awake(UI_LoginForm self,GObject transform)
        {
            self.GObject = transform;
            self.uiTransform = (GComponent)transform;
        }
    }

    [ObjectSystem]
    public class UI_LoginFormDestroySystem : DestroySystem<UI_LoginForm>
    {
        public override void Destroy(UI_LoginForm self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.uiTransform = null;
			self.m_Account = null;
			self.m_PassWord = null;
			self.m_LoginBtn = null;
        }
    }
}