using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class ConfigLoader: IConfigLoader
    {
        public void GetAllConfigBytes(Dictionary<string, byte[]> output)
        {
            foreach (var config in ResourcesComponent.Instance.ConfigBytes)
            {
                output.Add(config.Key,config.Value);
            }
        }

        public byte[] GetOneConfigBytes(string configName)
        {
            return ResourcesComponent.Instance.ConfigBytes[configName];
        }
    }
}