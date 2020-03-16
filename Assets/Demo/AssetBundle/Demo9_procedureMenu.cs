using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo9_ProcedureMenu : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架UI组件
        UIComponent UI
            = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();

        // 加载UI
        UI.OpenUIForm("Assets/Demo/AssetBundle/UI_Menu.prefab", "DefaultGroup");
    }
}
