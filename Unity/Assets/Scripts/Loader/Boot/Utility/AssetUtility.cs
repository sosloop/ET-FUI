

using GameFramework;

namespace UGFExtensions
{
    public static class AssetUtility
    {
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

        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UISounds/{0}.wav", assetName);
        }  
        public static string GetHotfixDLLAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/HotfixDll/{0}.bytes", assetName);
        }

    }
}
