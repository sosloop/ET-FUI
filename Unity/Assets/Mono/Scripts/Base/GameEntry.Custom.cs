using UGFExtensions.Hotfix;

namespace UGFExtensions
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry
    {

        /// <summary>
        /// 自定义数据组件
        /// </summary>
        public static BuiltinDataComponent BuiltinData { get; private set; }

        
        /// <summary>
        /// 数据表扩展组件
        /// </summary>
        public static HotfixComponent Hotfix { get; private set; }
        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            Hotfix = UnityGameFramework.Runtime.GameEntry.GetComponent<HotfixComponent>();
        }
    }
}