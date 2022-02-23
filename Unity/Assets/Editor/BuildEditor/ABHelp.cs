using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AB.Editor
{
    public static class ABHelp
    {
        [MenuItem("Assets/AssetBundle/ClearABName")]
        public static void ClearABName()
        {
            UnityEngine.Object[] selectAsset = Selection.GetFiltered<UnityEngine.Object>(SelectionMode.DeepAssets);
            for (int i = 0; i < selectAsset.Length; i++)
            {
                string prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                importer.assetBundleName = string.Empty;
                Debug.Log(prefabName);
            }
            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
    }
}
