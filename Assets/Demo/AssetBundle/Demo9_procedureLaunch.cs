using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo9_procedureLaunch : ProcedureBase
{
    private bool m_ResourceInitComplete = false;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        ResourceComponent Resource
            = UnityGameFramework.Runtime.GameEntry.GetComponent<ResourceComponent>();

        // 初始化资源
        Resource.InitResources(() => {
            OnResourceInitComplete();
        });
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (!m_ResourceInitComplete)
        {
            return;
        }

        SceneComponent Scene
            = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        // 切换场景
        Scene.LoadScene("Assets/Demo/AssetBundle/Demo9_menu.unity", this);

        // 切换流程
        ChangeState<Demo9_ProcedureMenu>(procedureOwner);
    }

    private void OnResourceInitComplete()
    {
        m_ResourceInitComplete = true;

        Log.Info("初始化资源成功");
    }
}
