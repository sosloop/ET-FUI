
using System;
using ET.Client.BootPack;
using FairyGUI;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using Log = UnityGameFramework.Runtime.Log;

namespace UGFExtensions
{
    public class BuiltinDataComponent : GameFrameworkComponent
    {
#if UNITY_ANDROID || UNITY_IOS
        public const string UpdateUrl = "https://tt.corki.cn/AB";
#else
        public const string UpdateUrl = "http://127.0.0.1:8088/AB";
#endif

        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        private BuildInfo m_BuildInfo = null;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }

        public FUI_BootUI FUIBootUI
        {
            get
            {
                if (mBootUI == null)
                {
                    this.mBootUI = FUI_BootUI.CreateInstance();
                    mBootUI.MakeFullScreen();
                    GRoot.inst.AddChild(mBootUI);
                }
                return this.mBootUI;
            }
        }

        private FUI_BootUI mBootUI = null;

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Error("Parse build info failure.");
            }
        }

        public void LoadBootPack()
        {
            GRoot.inst.SetContentScaleFactor(1136,640,UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
            UIPackage.AddPackage("FUI/BootPack");
            BootPackBinder.BindAll();
        }

        public void OpenDlgUpdateResource()
        {
            this.FUIBootUI.SetTip("开始启动");
            this.FUIBootUI.SetProgress(0,"");
        }

        public void ShowTip(string title,string content,Action action)
        {
            FUI_TipUI fuiTipUI = FUI_TipUI.CreateInstance();
            fuiTipUI.MakeFullScreen();
            fuiTipUI.ShowTip(title,content,action);
            this.FUIBootUI.AddChild(fuiTipUI);
        }

        public void CloseDlgUpdateResource()
        {
            if (mBootUI != null)
            {
                GRoot.inst.RemoveChild(this.mBootUI);
            }
        }

    }
}
