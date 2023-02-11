

using GameFramework;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

namespace UGFExtensions.Build.Editor
{
    public static class GameFrameworkConfigs
    {
        [BuildSettingsConfigPath]
        public static string BuildSettingsConfig = GameFramework.Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Bundles/GameFrameWorkConfigs/BuildSettings.xml"));

        [ResourceCollectionConfigPath]
        public static string ResourceCollectionConfig = GameFramework.Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Bundles/GameFrameWorkConfigs/ResourceCollection.xml"));

        [ResourceEditorConfigPath]
        public static string ResourceEditorConfig = GameFramework.Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Bundles/GameFrameWorkConfigs/ResourceEditor.xml"));

        [ResourceBuilderConfigPath]
        public static string ResourceBuilderConfig = GameFramework.Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Bundles/GameFrameWorkConfigs/ResourceBuilder.xml"));
    }
}

