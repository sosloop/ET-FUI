using UnityEngine;

namespace ET
{
    public class GlobalComponent: Entity, IAwake
    {
        public static GlobalComponent Instance;
        public Transform Unit;
    }
}