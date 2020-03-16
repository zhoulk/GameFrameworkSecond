using GameFramework;
using GameFramework.DataNode;
using GameFramework.Fsm;
using GameFramework.ObjectPool;
using GameFramework.Procedure;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo12_procedureLaunch : ProcedureBase {

    HPComponent poolComponent;

    List<HPBarItem> m_ActiveHPBarItems = new List<HPBarItem>();

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        //根据绝对路径设置与获取数据
        poolComponent = GameEntry.GetComponent<HPComponent>();
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (Input.GetMouseButtonDown(0))
        {
            //TestObject testObject = m_testPool.Spawn("test1");
            //Debug.Log(testObject.Target);
            //m_testPool.Unspawn(testObject.Target);

            HPBarItem item = poolComponent.ShowHP();

            m_ActiveHPBarItems.Add(item);
        }

        if (Input.GetMouseButtonDown(1))
        {
            //TestObject testObject = m_testPool.Spawn("test1");
            //Debug.Log(testObject.Target);
            //m_testPool.Unspawn(testObject.Target);

            if (m_ActiveHPBarItems.Count > 0)
            {
                HPBarItem item = m_ActiveHPBarItems[0];
                m_ActiveHPBarItems.RemoveAt(0);
                poolComponent.HideHP(item);
            }
        }
    }
}

