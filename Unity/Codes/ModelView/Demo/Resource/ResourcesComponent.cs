using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bright.Serialization;
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

        public UnityEngine.GameObject UnitPrefab;
        
        public void Awake()
        {
            Instance = this;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            Instance = null;
        }
        

        public async ETTask LoadUnitAsync()
        {
            UnitPrefab = await GameEntry.Resource.LoadAssetAsync<UnityEngine.GameObject>(AssetUtility.GetUnitAsset("Skeleton"));
        }
    }
}