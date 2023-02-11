using System;
using UGFExtensions;
using UGFExtensions.Await;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_AddComponent: AEvent<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeStart args)
        {
            Scene currentScene = scene.CurrentScene();
            
            string currentSceneName = currentScene.Name;
            
            string[] loadedSceneAssetNames = GameEntrys.Scene.GetLoadedSceneAssetNames();
            if (Array.Exists(loadedSceneAssetNames,x=>x==currentSceneName))
            {
                Log.Debug("在当前场景，不需要切换！");
                return;
            }
            
            // 停止所有声音
            GameEntrys.Sound.StopAllLoadingSounds();
            GameEntrys.Sound.StopAllLoadedSounds();

            // 隐藏所有实体
            GameEntrys.Entity.HideAllLoadingEntities();
            GameEntrys.Entity.HideAllLoadedEntities();

            // 卸载所有场景
            
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                GameEntrys.Scene.UnloadScene(loadedSceneAssetNames[i]);
            }

            // 还原游戏速度
            GameEntrys.Base.ResetNormalGameSpeed();
            
            // 切换场景
            bool loadSceneAsync = await GameEntrys.Scene.LoadSceneAsync($"Assets/Bundles/Scenes/{currentSceneName}.unity");
            if (loadSceneAsync)
            {
                currentScene.AddComponent<OperaComponent>();
            }
            else
            {
                Log.Error("切换场景失败！");
            }
        }
    }
}