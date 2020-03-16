using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo7_ProcedureLaunch : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 获取框架事件组件
        EventComponent Event
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
        Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
        // 获取框架网络组件
        WebRequestComponent WebRequest
            = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
        string url = "http://gameframework.cn/starforce/version.txt";
        WebRequest.AddWebRequest(url, this);
    }
    private void OnWebRequestSuccess(object sender, GameEventArgs e)
    {
        WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
        // 获取回应的数据
        string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());
        Log.Debug("responseJson：" + responseJson);
    }
    private void OnWebRequestFailure(object sender, GameEventArgs e)
    {
        Log.Warning("请求失败");
    }
}
