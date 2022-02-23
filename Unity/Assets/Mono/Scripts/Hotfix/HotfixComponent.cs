using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ET;
using FairyGUI;
using GameFramework.Resource;
using UGFExtensions.Await;
using UnityEngine;
using UnityGameFramework.Runtime;
using Log = ET.Log;
using Object = UnityEngine.Object;

namespace UGFExtensions.Hotfix
{
    public class HotfixComponent : GameFrameworkComponent
    {
        public CodeMode CodeMode = CodeMode.Mono;
        private GameObject _hotfixGo;
        
        
        public async void Enter()
        {
            
            GameEntry.BuiltinData.UpdateResourceForm.SetTip("更新完成");
            GameEntry.BuiltinData.UpdateResourceForm.SetProgress(100,"更新完成");
            
#if ILRuntime
			this.CodeMode = CodeMode.ILRuntime;
#endif
            CodeLoader.Instance.CodeMode = this.CodeMode;
            
            await CodeLoader.Instance.Start();

            _hotfixGo = new GameObject("HotfixInit",typeof(HotfixInit));
            _hotfixGo.transform.SetParent(transform);
            
            Log.Info($"<color=green>CodeMode = {CodeMode}</color>");
        }

        private void ShutDown()
        {
            Destroy(_hotfixGo);
        }

        
    }
}