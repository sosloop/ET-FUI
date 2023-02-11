using System;
using FairyGUI;

namespace ET.Client.BootPack
{
    public partial class FUI_TipUI
    {

        public void ShowTip(string title,string content,Action action)
        {
            this.title.text = title;
            this.content.text = content;
            this.show.SetSelectedIndex(0);
            this.yes.onClick.Set(() =>
            {
                action?.Invoke();
                this.Dispose();
            });
        }
        
        public void ShowTip(string title,string content,Action okAction,Action noAction)
        {
            this.title.text = title;
            this.content.text = content;
            this.show.SetSelectedIndex(1);
            this.ok.onClick.Set(() =>
            {
                okAction?.Invoke();
                this.Dispose();
            });
            this.no.onClick.Set(() =>
            {
                noAction?.Invoke();
                this.Dispose();
            });
        }
    }
}

