using System.IO;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.ResourceTools;

namespace UnityGameFramework.Editor.Auto
{
    public class AutoBuild
    {
        private const string relativeDirPrefix = "../Release/";

        private const string BuildFolder = "../Release/ABPackage";
        
        private static ResourceBuilderController m_Controller = null;
        
        [MenuItem("Game Framework/一键打包")]
        public static void OpenWindow()
        {
            EditorUtility.DisplayProgressBar("一键打包","开始准备",0);
            m_Controller = new ResourceBuilderController();
            
            if (m_Controller.Load())
            {
                Debug.Log("Load configuration success.");
                
                BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;
                
                switch (buildTarget)
                {
                    case BuildTarget.StandaloneWindows:
                        m_Controller.Platforms = Platform.Windows64;
                        break;
                    case BuildTarget.Android:
                        m_Controller.Platforms = Platform.Android;
                        break;
                    case BuildTarget.iOS:
                        m_Controller.Platforms = Platform.IOS;
                        break;
                    case BuildTarget.StandaloneOSX:
                        m_Controller.Platforms = Platform.MacOS;
                        break;
                }
                
                m_Controller.RefreshBuildEventHandler();
                
                BuildResources();
            }
            else
            {
                Debug.LogWarning("Load configuration failure.");
            }
            
        }
   
        
        private static void BuildResources()
        {
            Debug.Log("开始build！");
            if (!Directory.Exists(BuildFolder))
            {
                Debug.Log("文件夹不存在，创建文件夹！");
                Directory.CreateDirectory(BuildFolder);
            }

            m_Controller.OutputDirectory = BuildFolder;
            
            // 设置当前所选平台
            // m_Controller.SelectPlatform(Platform.Windows, true);
            
            if (m_Controller.BuildResources())
            {
                Debug.Log("Build resources success.");
                SaveConfiguration();
            }
            else
            {
                Debug.LogWarning("Build resources failure.");
            }
        }

        private static void SaveConfiguration()
        {
            if (m_Controller.Save())
            {
                Debug.Log("Save configuration success.");
                
                BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;
                string exeName = "Game";
                BuildOptions buildOptions = BuildOptions.None;
                
                switch (buildTarget)
                {
                    case BuildTarget.StandaloneWindows:
                        buildTarget = BuildTarget.StandaloneWindows64;
                        exeName += ".exe";
                        break;
                    case BuildTarget.Android:
                        buildTarget = BuildTarget.Android;
                        exeName += ".apk";
                        break;
                    case BuildTarget.iOS:
                        buildTarget = BuildTarget.iOS;
                        break;
                    case BuildTarget.StandaloneOSX:
                        buildTarget = BuildTarget.StandaloneOSX;
                        break;
                }

                string fold = string.Format(relativeDirPrefix, buildTarget);
                if (!Directory.Exists(fold))
                {
                    Directory.CreateDirectory(fold);
                }
                
                AssetDatabase.Refresh();
                
                string locationPathName = $"{relativeDirPrefix}/{exeName}";
                Debug.Log("开始EXE打包="+locationPathName);
                
                BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, locationPathName, buildTarget, buildOptions);
                Debug.Log($"完成 {buildTarget} 打包,路径为："+locationPathName);
                EditorUtility.RevealInFinder(locationPathName);
            }
            else
            {
                Debug.LogWarning("Save configuration failure.");
            }
        }
    }
}