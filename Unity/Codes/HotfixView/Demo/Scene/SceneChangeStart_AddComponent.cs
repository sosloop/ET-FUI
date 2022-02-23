using UGFExtensions;
using UGFExtensions.Await;

namespace ET
{
    public class SceneChangeStart_AddComponent: AEvent<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(EventType.SceneChangeStart args)
        {
            Scene currentScene = args.ZoneScene.CurrentScene();
            
            string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                GameEntry.Scene.UnloadScene(loadedSceneAssetNames[i]);
            }
            
            // 加载场景资源
            await GameEntry.Scene.LoadSceneAsync(AssetUtility.GetSceneAsset(currentScene.Name));

            
            // 切换到map场景

            // SceneChangeComponent sceneChangeComponent = null;
            // try
            // {
            //     sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
            //     {
            //         await sceneChangeComponent.ChangeSceneAsync(currentScene.Name);
            //     }
            // }
            // finally
            // {
            //     sceneChangeComponent?.Dispose();
            // }
			

            currentScene.AddComponent<OperaComponent>();
        }
    }
}