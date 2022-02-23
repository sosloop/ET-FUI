using GameFramework.Fsm;
using GameFramework.Procedure;
using ILRuntime.Runtime.Intepreter;

namespace UGFExtensions
{
    public class ProcedureEnterHotfix : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Hotfix.Enter();
        }
    }
}