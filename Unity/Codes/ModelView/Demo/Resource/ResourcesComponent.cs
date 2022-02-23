using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UGFExtensions;
using UGFExtensions.Await;
using UnityEngine;

namespace ET
{
    
    [ObjectSystem]
    public class ResourcesComponentAwakeSystem: AwakeSystem<ResourcesComponent>
    {
        public override void Awake(ResourcesComponent self)
        {
            self.Awake();
        }
    }

    public class ResourcesComponent: Entity, IAwake
    {
        public static ResourcesComponent Instance { get; set; }

        public Dictionary<string, byte[]> ConfigBytes = new Dictionary<string, byte[]>();
        public UnityEngine.GameObject UnitPrefab;
        
        public void Awake()
        {
            Instance = this;
            ConfigBytes.Clear();
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            Instance = null;
            ConfigBytes.Clear();
        }

        public async ETTask LoadAllConfigAsync()
        {
            if (ConfigBytes.Count > 0)
            {
                return;
            }

            try
            {
                HashSet<Type> types = Game.EventSystem.GetTypes(typeof (ConfigAttribute));
                foreach (Type type in types)
                {
                    TextAsset textAssets = await GameEntry.Resource.LoadAssetAsync<TextAsset>(AssetUtility.GetHotfixConfigAsset(type.Name));
                    ConfigBytes[type.Name] = textAssets.bytes;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public async ETTask LoadUnitAsync()
        {
            UnitPrefab = await GameEntry.Resource.LoadAssetAsync<UnityEngine.GameObject>(AssetUtility.GetUnitAsset("Skeleton"));
        }
    }
}