using System;
using System.Threading;
using UnityEngine;
using ET;

namespace UGFExtensions
{

    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntrys : MonoBehaviour
    {

        public static GameEntrys Inst { get; private set; }

        // private void Awake()
        // {
        //     DontDestroyOnLoad(this.gameObject);
        // }

        private void Awake()
        {
            Inst = this;
        }

        private void OnDestroy()
        {
            Inst = null;
        }

        private void Start()
        {

            InitBuiltinComponents();
            InitCustomComponents();
        }

    }
}