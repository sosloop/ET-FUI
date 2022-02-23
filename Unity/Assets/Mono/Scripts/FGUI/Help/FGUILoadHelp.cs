using System;
using ET;
using FairyGUI;
using UGFExtensions.Await;
using UnityEngine;

namespace UGFExtensions
{
    public class FGUILoadHelp
    {
        public static FGUILoadHelp Instance = new FGUILoadHelp();

        public async ETTask<UIPackage> AddPackageAsync(string type)
        {
            string assetName = AssetUtility.GetFGUIFormAsset($"{type}.prefab");
            GameObject gameObject = await GameEntry.Resource.LoadAssetAsync<GameObject>(assetName);
            ReferenceCollector referenceCollector = gameObject.GetComponent<ReferenceCollector>();
                
            UIPackage uiPackage = UIPackage.AddPackage(type, delegate(string name, string extension, Type type1, out DestroyMethod destroymethod)
            {
                destroymethod = DestroyMethod.None;
                if (type1 == typeof(TextAsset))
                {
                    return referenceCollector.Get<TextAsset>(name);
                }
                if (type1 == typeof(Texture))
                {
                    return referenceCollector.Get<Texture>(name);
                }
                if (type1 == typeof(AudioClip))
                {
                    return referenceCollector.Get<AudioClip>(name);
                }
                return null;
            });
            return uiPackage;
        }
    }
}