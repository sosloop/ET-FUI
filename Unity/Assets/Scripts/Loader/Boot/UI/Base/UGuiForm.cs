//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace UGFExtensions
{
    public abstract class UGuiForm : UIFormLogic
    {
        public const int DepthFactor = 10;
        private Canvas m_CachedCanvas = null;
        private List<Canvas> m_CachedCanvasContainer = new List<Canvas>();
        
        public int OriginalDepth
        {
            get;
            private set;
        }

        public int Depth
        {
            get
            {
                return m_CachedCanvas.sortingOrder;
            }
        }

        public void Close()
        {
            GameEntrys.UI.CloseUIForm(this.UIForm);
        }

        protected internal override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
            m_CachedCanvas.overrideSorting = true;
            OriginalDepth = m_CachedCanvas.sortingOrder;
            
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localPosition = Vector3.zero;
            
            gameObject.GetOrAddComponent<GraphicRaycaster>();
        }
        

        protected internal override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            int oldDepth = Depth;
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            int deltaDepth = UGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth + OriginalDepth;
            GetComponentsInChildren(true, m_CachedCanvasContainer);
            for (int i = 0; i < m_CachedCanvasContainer.Count; i++)
            {
                m_CachedCanvasContainer[i].sortingOrder += deltaDepth;
            }

            m_CachedCanvasContainer.Clear();
        }
        
        public void SetLayer(bool isUILayer)
        {
            if (!Visible)
            {
                Log.Warning($"{this.gameObject.name} Visible={Visible}");
                return;
            }
            gameObject.SetLayerRecursively(isUILayer?LayerMask.NameToLayer("UI"):LayerMask.NameToLayer("Hide"));
            if (isUILayer)
            {
                GameEntrys.UI.RefocusUIForm(this.UIForm);
            }
        }

    }
}