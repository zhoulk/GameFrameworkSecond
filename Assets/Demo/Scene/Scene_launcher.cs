
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Scene_launcher : ProcedureBase
{
    protected internal override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("初始！！");

        SceneComponent scene
            = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        // 切换场景
        scene.LoadScene("Assets/Demo/Scene/sceneMenu.unity", this);

        // 切换流程
        ChangeState<Scene_Menu>(procedureOwner);
    }
}
