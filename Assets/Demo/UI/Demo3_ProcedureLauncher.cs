using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo3_ProcedureLauncher : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        SceneComponent scene
            = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        // 切换场景

        scene.LoadScene("Assets/Demo/UI/Demo3_Menu.unity", this);

        // 切换流程

        ChangeState<Demo3_ProcedureMenu>(procedureOwner);
    }
}
