

namespace UGFExtensions
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntrys
    {

        /// <summary>
        /// 自定义数据组件
        /// </summary>
        public static BuiltinDataComponent BuiltinData { get; private set; }


        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
        }
    }
}