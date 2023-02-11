
using System.Collections.Generic;
using ET;
using GameFramework.Fsm;
using GameFramework.Procedure;

namespace UGFExtensions
{
    public class ProcedureEnterHotfix: ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            GameEntrys.Inst.gameObject.AddComponent<Init>();
        }
    }
}