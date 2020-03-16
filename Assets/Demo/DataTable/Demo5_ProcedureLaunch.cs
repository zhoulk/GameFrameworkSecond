using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using StarForce;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo5_ProcedureLaunch : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 获取框架事件组件
        EventComponent Event
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        // 获取框架数据表组件
        DataTableComponent DataTable
            = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
        // 订阅加载成功事件
        Event.Subscribe(UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        // 加载配置表
        DataTable.LoadDataTable<DRheros>("Hero", "Assets/Demo/DataTable/heros.txt", GameFramework.LoadType.Text);
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        // 获取框架数据表组件
        DataTableComponent DataTable
            = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
        // 获得数据表
        IDataTable<DRheros> dtScene = DataTable.GetDataTable<DRheros>();

        // 获得所有行
        DRheros[] drHeros = dtScene.GetAllDataRows();
        Log.Debug("drHeros:" + drHeros.Length);
        // 根据行号获得某一行
        DRheros drScene = dtScene.GetDataRow(1); // 或直接使用 dtScene[1]
        if (drScene != null)
        {
            // 此行存在，可以获取内容了
            string name = drScene.Name;
            int atk = drScene.Atk;
            Log.Debug("name:" + name + ", atk:" + atk);
        }
        else
        {
            // 此行不存在
        }
        // 获得满足条件的所有行
        DRheros[] drScenesWithCondition = dtScene.GetDataRows(x => x.Id > 0);

        // 获得满足条件的第一行
        DRheros drSceneWithCondition = dtScene.GetDataRow(x => x.Name == "mutou");

    }
}
