using System;
using System.IO;
using Bright.Serialization;

namespace ET
{
    public partial class Tables
    {
        private bool _isLoad = false;
        private ETTask _etTask;
        partial void PostResolve()
        {
            _isLoad = true;
            
            this._etTask?.SetResult();
            this._etTask = null;
        }

        /// <summary>
        /// 异步加载等待结束
        /// </summary>
        public async ETTask LoadAsync()
        {
            if (!_isLoad)
            {
                this._etTask = ETTask.Create();

                await this._etTask;
            }

            await ETTask.CompletedTask;

        }

    }

    public class TablesHelp
    {
        public static TablesHelp Instance = new TablesHelp();

        private TablesHelp()
        {
            
        }

        public Tables Tables {
            get
            {
                return _tables;
            }
        }
        private Tables _tables;
        
        public async ETTask LoadAllConfigAsync()
        {
            try
            {
                _tables = new Tables(LoadByteBuf);
                await Tables.LoadAsync();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
        private ByteBuf LoadByteBuf(string file)
        {
            return new ByteBuf(File.ReadAllBytes($"../Config/Excel/{file}.bytes"));
        }
    }
}