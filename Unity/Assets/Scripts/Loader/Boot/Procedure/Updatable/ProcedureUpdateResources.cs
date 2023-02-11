using GameFramework;
using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UGFExtensions
{
    public class ProcedureUpdateResources : ProcedureBase
    {
        private bool m_UpdateResourcesComplete = false;
        private int m_UpdateCount = 0;
        private long m_UpdateTotalCompressedLength = 0L;
        private int m_UpdateSuccessCount = 0;
        private List<UpdateLengthData> m_UpdateLengthData = new List<UpdateLengthData>();

        public override bool UseNativeDialog
        {
            get { return true; }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_UpdateResourcesComplete = false;
            m_UpdateCount = procedureOwner.GetData<VarInt32>("UpdateResourceCount");
            procedureOwner.RemoveData("UpdateResourceCount");
            m_UpdateTotalCompressedLength = procedureOwner.GetData<VarInt64>("UpdateResourceTotalCompressedLength");
            procedureOwner.RemoveData("UpdateResourceTotalCompressedLength");
            m_UpdateSuccessCount = 0;
            m_UpdateLengthData.Clear();

            GameEntrys.Event.Subscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            GameEntrys.Event.Subscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            GameEntrys.Event.Subscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            GameEntrys.Event.Subscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);

            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                // GameEntrys.UI.OpenDialog(new DialogParams
                // {
                //     Mode = 2,
                //     Title = GameEntrys.Localization.GetString("UpdateResourceViaCarrierDataNetwork.Title"),
                //     Message = GameEntrys.Localization.GetString("UpdateResourceViaCarrierDataNetwork.Message"),
                //     ConfirmText = GameEntrys.Localization.GetString("UpdateResourceViaCarrierDataNetwork.UpdateButton"),
                //     OnClickConfirm = StartUpdateResources,
                //     CancelText = GameEntrys.Localization.GetString("UpdateResourceViaCarrierDataNetwork.QuitButton"),
                //     OnClickCancel = delegate { UnityGameFramework.Runtime.GameEntrys.Shutdown(ShutdownType.Quit); },
                // });

                return;
            }

            StartUpdateResources(null);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntrys.Event.Unsubscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            GameEntrys.Event.Unsubscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            GameEntrys.Event.Unsubscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            GameEntrys.Event.Unsubscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_UpdateResourcesComplete)
            {
                return;
            }

            ChangeState<ProcedureEnterHotfix>(procedureOwner);
        }

        private void StartUpdateResources(object userData)
        {
            Log.Info("Start update resources...");
            GameEntrys.Resource.UpdateResources(OnUpdateResourcesComplete);
        }

        private void RefreshProgress()
        {
            long currentTotalUpdateLength = 0L;
            for (int i = 0; i < m_UpdateLengthData.Count; i++)
            {
                currentTotalUpdateLength += m_UpdateLengthData[i].Length;
            }

            float progressTotal = (float)currentTotalUpdateLength / m_UpdateTotalCompressedLength;
            string descriptionText = string.Format("{0}/{1}, {2}/{3}, {4:P0}, {5}/s",
                m_UpdateSuccessCount.ToString(), m_UpdateCount.ToString(),
                GetByteLengthString(currentTotalUpdateLength), GetByteLengthString(m_UpdateTotalCompressedLength),
                progressTotal, GetByteLengthString((int)GameEntrys.Download.CurrentSpeed));
            GameEntrys.BuiltinData.FUIBootUI.SetProgress(progressTotal, descriptionText);
        }

        private string GetByteLengthString(long byteLength)
        {
            if (byteLength < 1024L) // 2 ^ 10
            {
                return Utility.Text.Format("{0} Bytes", byteLength);
            }

            if (byteLength < 1048576L) // 2 ^ 20
            {
                return Utility.Text.Format("{0:F2} KB", byteLength / 1024f);
            }

            if (byteLength < 1073741824L) // 2 ^ 30
            {
                return Utility.Text.Format("{0:F2} MB", byteLength / 1048576f);
            }

            if (byteLength < 1099511627776L) // 2 ^ 40
            {
                return Utility.Text.Format("{0:F2} GB", byteLength / 1073741824f);
            }

            if (byteLength < 1125899906842624L) // 2 ^ 50
            {
                return Utility.Text.Format("{0:F2} TB", byteLength / 1099511627776f);
            }

            if (byteLength < 1152921504606846976L) // 2 ^ 60
            {
                return Utility.Text.Format("{0:F2} PB", byteLength / 1125899906842624f);
            }

            return Utility.Text.Format("{0:F2} EB", byteLength / 1152921504606846976f);
        }

        private void OnUpdateResourcesComplete(GameFramework.Resource.IResourceGroup resourceGroup, bool result)
        {
            if (result)
            {
                m_UpdateResourcesComplete = true;
                Log.Info("Update resources complete with no errors.");
            }
            else
            {
                Log.Error("Update resources complete with errors.");
            }
        }

        private void OnResourceUpdateStart(object sender, GameEventArgs e)
        {
            ResourceUpdateStartEventArgs ne = (ResourceUpdateStartEventArgs)e;

            for (int i = 0; i < m_UpdateLengthData.Count; i++)
            {
                if (m_UpdateLengthData[i].Name == ne.Name)
                {
                    Log.Warning("Update resource '{0}' is invalid.", ne.Name);
                    m_UpdateLengthData[i].Length = 0;
                    RefreshProgress();
                    return;
                }
            }

            m_UpdateLengthData.Add(new UpdateLengthData(ne.Name));
        }

        private void OnResourceUpdateChanged(object sender, GameEventArgs e)
        {
            ResourceUpdateChangedEventArgs ne = (ResourceUpdateChangedEventArgs)e;

            for (int i = 0; i < m_UpdateLengthData.Count; i++)
            {
                if (m_UpdateLengthData[i].Name == ne.Name)
                {
                    m_UpdateLengthData[i].Length = ne.CurrentLength;
                    RefreshProgress();
                    return;
                }
            }

            Log.Warning("Update resource '{0}' is invalid.", ne.Name);
        }

        private void OnResourceUpdateSuccess(object sender, GameEventArgs e)
        {
            ResourceUpdateSuccessEventArgs ne = (ResourceUpdateSuccessEventArgs)e;
            Log.Info("Update resource '{0}' success.", ne.Name);

            for (int i = 0; i < m_UpdateLengthData.Count; i++)
            {
                if (m_UpdateLengthData[i].Name == ne.Name)
                {
                    m_UpdateLengthData[i].Length = ne.CompressedLength;
                    m_UpdateSuccessCount++;
                    RefreshProgress();
                    return;
                }
            }

            Log.Warning("Update resource '{0}' is invalid.", ne.Name);
        }

        private void OnResourceUpdateFailure(object sender, GameEventArgs e)
        {
            ResourceUpdateFailureEventArgs ne = (ResourceUpdateFailureEventArgs)e;
            if (ne.RetryCount >= ne.TotalRetryCount)
            {
                Log.Error("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.",
                    ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
                return;
            }
            else
            {
                Log.Info("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.",
                    ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
            }

            for (int i = 0; i < m_UpdateLengthData.Count; i++)
            {
                if (m_UpdateLengthData[i].Name == ne.Name)
                {
                    m_UpdateLengthData.Remove(m_UpdateLengthData[i]);
                    RefreshProgress();
                    return;
                }
            }

            Log.Warning("Update resource '{0}' is invalid.", ne.Name);
        }

        private class UpdateLengthData
        {
            private readonly string m_Name;

            public UpdateLengthData(string name)
            {
                m_Name = name;
            }

            public string Name
            {
                get { return m_Name; }
            }

            public int Length { get; set; }
        }
    }
}