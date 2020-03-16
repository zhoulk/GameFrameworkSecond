using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo10_procedureLaunch : ProcedureBase {

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
        entityComponent.ShowEntity<Demo10_HeroCube>(1, "Assets/Demo/Fsm/Cube.prefab", "cubes");
    }
}
