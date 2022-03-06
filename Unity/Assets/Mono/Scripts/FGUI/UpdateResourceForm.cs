using System;
using ET;
using ET.UModel;
using FairyGUI;

namespace UGFExtensions
{
    public class UpdateResourceForm : IDisposable
    {
        private UI_UpdateForm uiUpdateForm1;

        public UpdateResourceForm()
        {
            UIPackage.AddPackage("FGUI/UModel");
            UModelBinder.BindAll();
            this.uiUpdateForm1 = UI_UpdateForm.CreateInstance();
            this.uiUpdateForm1.MakeFullScreen();
            GRoot.inst.AddChild(uiUpdateForm1);
        }
        

        public void Dispose()
        {
            uiUpdateForm1?.Dispose();
            uiUpdateForm1 = null;
        }

        public void SetTip(string tipText)
        {
            uiUpdateForm1.m_Tip.text = tipText;
        }

        public void SetProgress(float progressTotal, string descriptionText)
        {
            uiUpdateForm1.m_Progress.value = progressTotal;
        }
    }
}