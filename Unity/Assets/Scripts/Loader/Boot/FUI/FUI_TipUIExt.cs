using System;
using FairyGUI;
using UGFExtensions;

namespace ET.Client.BootPack
{
    public partial class FUI_TipUI
    {
        public void ShowTip(string title, string content, Action action, bool showUrl = false)
        {
            this.title.text = title;
            this.content.text = content;
            this.show.SetSelectedIndex(0);
            this.seturl.SetSelectedIndex(showUrl? 1 : 0);
            this.server.set.onClick.Set(() =>
            {
                string url = this.server.server.text;
                BuiltinDataComponent.UpdateUrl = url;
            });
            
            this.yes.onClick.Set(() =>
            {
                action?.Invoke();
                this.Dispose();
            });
        }

        public void ShowTip(string title, string content, Action okAction, Action noAction, bool showUrl = false)
        {
            this.title.text = title;
            this.content.text = content;
            this.show.SetSelectedIndex(1);
            this.seturl.SetSelectedIndex(showUrl? 1 : 0);
            this.server.set.onClick.Set(() =>
            {
                string url = this.server.server.text;
                BuiltinDataComponent.UpdateUrl = url;
            });
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