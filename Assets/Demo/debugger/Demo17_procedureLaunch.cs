
using GameFramework.Fsm;
using GameFramework.Procedure;

public class Demo17_procedureLaunch : ProcedureBase {

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        //// 加载框架Event组件
        //settingComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();

        //settingComponent.SetInt("HP", 100);
        //settingComponent.Save();

        //Log.Info(settingComponent.GetInt("HP"));
    }
}
