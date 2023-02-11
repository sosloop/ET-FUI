using System;
using UnityGameFramework.Runtime;
using GameFramework.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGFExtensions
{
    public class UGUIFormHelper : UIFormHelperBase
    {
        private ResourceComponent m_ResourceComponent = null;

        /// <summary>
        /// 实例化界面。
        /// </summary>
        /// <param name="uiFormAsset">要实例化的界面资源。</param>
        /// <returns>实例化后的界面。</returns>
        public override object InstantiateUIForm(object uiFormAsset)
        {
            return Instantiate((Object)uiFormAsset);
        }

        /// <summary>
        /// 创建界面。
        /// </summary>
        /// <param name="uiFormInstance">界面实例。</param>
        /// <param name="uiGroup">界面所属的界面组。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面。</returns>
        public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
        {
            GameObject instanceGo = uiFormInstance as GameObject;
            if (instanceGo == null)
            {
                Log.Error("UI form instance is invalid.");
                return null;
            }
            string typeName = instanceGo.name.Replace("(Clone)", string.Empty);
            instanceGo.name = typeName;

            Transform transform1 = instanceGo.transform;
            transform1.SetParent(((MonoBehaviour)uiGroup.Helper).transform);
            transform1.localScale = Vector3.one;

            return instanceGo.GetOrAddComponent<UIForm>();
        }

        /// <summary>
        /// 释放界面。
        /// </summary>
        /// <param name="uiFormAsset">要释放的界面资源。</param>
        /// <param name="uiFormInstance">要释放的界面实例。</param>
        public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
        {
            m_ResourceComponent.UnloadAsset(uiFormAsset);
            Destroy((Object)uiFormInstance);
        }

        private void Start()
        {
            m_ResourceComponent = GameEntry.GetComponent<ResourceComponent>();
            if (m_ResourceComponent == null)
            {
                Log.Fatal("Resource component is invalid.");
                return;
            }
        }
    }
}