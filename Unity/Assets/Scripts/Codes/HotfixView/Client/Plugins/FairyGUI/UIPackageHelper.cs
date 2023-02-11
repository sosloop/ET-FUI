using System;
using System.Collections.Generic;
using FairyGUI;
using UGFExtensions;
using UGFExtensions.Await;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(FUIComponent))]
    public static class UIPackageHelper
    {
        public static async ETTask<GComponent> CreateObjectAsync(string packageName, string componentName)
        {
            ETTask<GComponent> task = ETTask<GComponent>.Create(true);
            UIPackage.CreateObjectAsync(packageName, componentName, result =>
            {
                task.SetResult(result.asCom);
            });
            return await task;
        }

        /// <summary>
        /// 增加 FariyGUI 的 Package
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName"></param>
        public static async ETTask AddPackageAsync(this FUIComponent self, string packageName)
        {
            byte[] descData = GameEntrys.Resource.LoadBinaryFromFileSystem($"Assets/Bundles/FUI/{packageName}_fui.bytes");

            UIPackage.AddPackage(descData, packageName, delegate(string name, string extension, Type type, PackageItem item)
            {
                self.InnerLoader(name, extension, type, item).Coroutine();
            });

            await ETTask.CompletedTask;
        }

        private static async ETTask InnerLoader(this FUIComponent self, string location, string extension, Type type, PackageItem item)
        {
            var res = await GameEntrys.Resource.LoadAssetAsync(type,$"Assets/Bundles/FUI/{location}{extension}");
            item.owner.SetItemAsset(item, res, DestroyMethod.None);

            string pacakgeName = item.owner.name;
            self.UIPackageLocations.Add(pacakgeName, res);
        }

        /// <summary>
        /// 移除 FariyGUI 的 Package
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName"></param>
        public static void RemovePackage(this FUIComponent self, string packageName)
        {
            UIPackage.RemovePackage(packageName);

            List<object> list = self.UIPackageLocations[packageName];
            foreach (object location in list)
            {
                GameEntrys.Resource.UnloadAsset(location);
            }
        }
    }
}