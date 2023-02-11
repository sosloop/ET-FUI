using System.Collections.Generic;
using HybridCLR;
using UGFExtensions;
using UnityEngine;

namespace ET
{
    public static class HybridCLRHelper
    {
        public static void Load()
        {
            string AOTCode_Prefix = "Assets/Bundles/AOTCode";
            
            List<string> AOTMetaAssemblyNames = new List<string>()
            {
                "CommandLine.dll.bytes",
                "MongoDB.Bson.dll.bytes",
                "mscorlib.dll.bytes",
                "NLog.dll.bytes",
                "System.Core.dll.bytes",
                "System.dll.bytes",
                "Unity.Core.dll.bytes",
                "Unity.Loader.dll.bytes",
                "Unity.ThirdParty.dll.bytes",
            };

            foreach (string aotDll in AOTMetaAssemblyNames)
            {
                byte[] bytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{AOTCode_Prefix}/{aotDll}");
                RuntimeApi.LoadMetadataForAOTAssembly(bytes, HomologousImageMode.Consistent);
            }
        }
    }
}