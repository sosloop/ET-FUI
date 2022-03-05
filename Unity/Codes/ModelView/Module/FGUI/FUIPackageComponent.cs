using System;
using System.Collections.Generic;
using FairyGUI;
using GameFramework;
using GameFramework.Resource;
using UGFExtensions;
using UGFExtensions.Await;
using UnityEngine;

namespace ET
{

    [ObjectSystem]
    public class FUIPackageComponentAwakeSystem: AwakeSystem<FUIPackageComponent>
    {
        public override void Awake(FUIPackageComponent self)
        {
            FUIPackageComponent.Instance = self;
        }
    }

    public class FUIPackageComponent : Entity,IAwake
    {
        public static FUIPackageComponent Instance = null;
        
        public const string FUI_PACKAGE_DIR = "Assets/Res/FGUI";

        public Dictionary<string, UIPackage> packages = new Dictionary<string, UIPackage>();
        public List<string> loadingPkg = new List<string>();


        public async ETTask AddPackageAsync(string type)
        {
            if (loadingPkg.IndexOf(type) != -1 || packages.ContainsKey(type))
            {
                Log.Debug($"{type}包已经加载");
                return;
            }
            
            Log.Debug($"<color=green>AddPackageAsync {type}包</color>");
            if (GameEntry.Base.EditorResourceMode)
            {
                UIPackage uiPackage = UIPackage.AddPackage($"{FUI_PACKAGE_DIR}/{type}");
                
                packages.Add(type, uiPackage);
            }
            else
            {
                loadingPkg.Add(type);

                UIPackage uiPackage = await FGUILoadHelp.Instance.AddPackageAsync(type);
                //
                packages.Add(type, uiPackage);
                
                loadingPkg.Remove(type);
            }

        }
        

        public void RemovePackage(string type)
        {
            if (!packages.ContainsKey(type))
            {
                Log.Debug($"{type}包已经卸载");
                return;
            }
            UIPackage package;
            
            if(packages.TryGetValue(type, out package))
            {
                var p = UIPackage.GetByName(package.name);

                if (p != null)
                {
                    UIPackage.RemovePackage(package.name);
                }

                packages.Remove(package.name);
            }

        }

        public async ETTask<GObject> CreateGo(string packageName,string res)
        {
            ETTask<GObject> tcs = ETTask<GObject>.Create(true);
            UIPackage.CreateObjectAsync(packageName,res, (go) =>
            {
                tcs.SetResult(go);
            });
            return await tcs;
        }


    }
}