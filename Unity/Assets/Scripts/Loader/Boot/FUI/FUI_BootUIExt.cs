using UnityEngine;

namespace ET.Client.BootPack
{
    
    public partial class FUI_BootUI
    {
        
        public void SetTip(string tip)
        {
            this.title.text = tip;
        }

        public void SetProgress(float progressTotal, string descriptionText)
        {
            this.progress.value = progressTotal;
            this.info.text = descriptionText;
        }
    }
}

