using System.Threading;
using UnityEngine;
using ET;

namespace UGFExtensions
{
    
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        
        private void Awake()
        {
            System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error(e.ExceptionObject.ToString());
            };
			
            SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
			
            ETTask.ExceptionHandler += Log.Error;

            Log.ILog = new UnityLogger();

            Options.Instance = new Options();
        }
        
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
        }

    }
}