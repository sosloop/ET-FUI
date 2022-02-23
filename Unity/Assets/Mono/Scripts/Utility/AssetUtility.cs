

using GameFramework;

namespace UGFExtensions
{
    public static class AssetUtility
    {
        public static string GetConfigAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Configs/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDataTableAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDictionaryAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language.ToString(), assetName, fromBytes ? "bytes" : "xml");
        }

        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Fonts/{0}.ttf", assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Entities/{0}.prefab", assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UIForms/{0}.prefab", assetName);
        }
        
        public static string GetFGUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/FGUI/{0}", assetName);
        }
        
        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UISounds/{0}.wav", assetName);
        }  
        public static string GetHotfixDLLAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/HotfixDll/{0}.bytes", assetName);
        }
        
        public static string GetHotfixConfigAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/DataTables/Hotfix/{0}.bytes", assetName);
        }
        
        public static string GetUnitAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Unit/Skeleton/{0}.prefab", assetName);
        }
    }
}
