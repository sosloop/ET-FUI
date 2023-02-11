using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerEx : CanvasScaler
{
    
    protected override void HandleScaleWithScreenSize()
    {
        // 果只需适配手机，即更细长的屏幕（长边大于1920），我们希望高度不变，宽度变大。把Match设置1即可
        // 如果只需适配平板，即更方的屏幕（短边大于1080），我们希望高度不变，宽度变大。这时只需把Match设置0即可
        matchWidthOrHeight = Screen.width / m_ReferenceResolution.x > Screen.height / m_ReferenceResolution.y ? 1f : 0f;

        base.HandleScaleWithScreenSize();
    }
}