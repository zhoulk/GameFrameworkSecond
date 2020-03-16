
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Localization;
using GameFramework.Procedure;
using GameFramework.Sound;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;
using LoadDictionarySuccessEventArgs = UnityGameFramework.Runtime.LoadDictionarySuccessEventArgs;

public class Demo16_procedureLaunch : ProcedureBase {

    SettingComponent settingComponent;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        settingComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();

        settingComponent.SetInt("HP", 100);
        settingComponent.Save();

        Log.Info(settingComponent.GetInt("HP"));
    }
}
