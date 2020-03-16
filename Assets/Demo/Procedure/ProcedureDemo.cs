using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureDemo : ProcedureBase {

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        string welcomeMessage = "HelloWorld!";

        Log.Info(welcomeMessage);

        Log.Warning(welcomeMessage);

        Log.Error(welcomeMessage);
    }

}
