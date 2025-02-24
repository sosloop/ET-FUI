﻿

using GameFramework;
using UGFExtensions;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = UnityGameFramework.Runtime.GameEntry;

namespace UGFExtensions
{
    public class BuiltinDataComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset = null;

        
        private BuildInfo m_BuildInfo = null;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }
        
        public UpdateResourceForm UpdateResourceForm
        {
            get
            {
                return m_UpdateResourceForm;
            }
        }

        private UpdateResourceForm m_UpdateResourceForm = null;
        
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
                Log.Warning("Parse build info failure.");
                return;
            }
            m_UpdateResourceForm = new UpdateResourceForm();
        }

        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not be found or empty.");
                return;
            }

            if (!GameEntry.Localization.ParseData(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }
    }
}
