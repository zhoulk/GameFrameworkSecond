using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo20_procedureLaunch : ProcedureBase {

    List<Demo20Modle> m_list = new List<Demo20Modle>();

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (Input.GetMouseButtonDown(0))
        {
            Demo20Modle modle = Demo20Modle.Create(100);
            Log.Info(modle.Num);
            m_list.Add(modle);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(m_list.Count > 0)
            {
                ReferencePool.Release(m_list[0]);
                m_list.Remove(m_list[0]);
            }
        }
    }

}

class Demo20Modle : IReference
{
    public static Demo20Modle Create(int num)
    {
        Demo20Modle modle = ReferencePool.Acquire<Demo20Modle>();
        modle.Num = num;
        return modle;
    }

    public int Num
    {
        get;
        private set;
    }

    public void Clear()
    {
        Num = 0;
    }
}
