using ET;
using UnityEngine;

namespace UGFExtensions.Hotfix
{
    public class HotfixInit : MonoBehaviour
    {
        private void Update()
        {
            CodeLoader.Instance.Update();
        }

        private void LateUpdate()
        {
            CodeLoader.Instance.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            CodeLoader.Instance.OnApplicationQuit();
            CodeLoader.Instance.Dispose();
        }
    }
}