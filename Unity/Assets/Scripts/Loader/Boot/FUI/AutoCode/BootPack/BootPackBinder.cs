/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client.BootPack
{
    public class BootPackBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(FUI_BootUI.URL, typeof(FUI_BootUI));
            UIObjectFactory.SetPackageItemExtension(FUI_MaskBg.URL, typeof(FUI_MaskBg));
            UIObjectFactory.SetPackageItemExtension(FUI_MaskTransparentBg.URL, typeof(FUI_MaskTransparentBg));
            UIObjectFactory.SetPackageItemExtension(FUI_TipUI.URL, typeof(FUI_TipUI));
            UIObjectFactory.SetPackageItemExtension(FUI_NetLoadingUI.URL, typeof(FUI_NetLoadingUI));
            UIObjectFactory.SetPackageItemExtension(FUI_GlobalModalWaiting.URL, typeof(FUI_GlobalModalWaiting));
        }
    }
}