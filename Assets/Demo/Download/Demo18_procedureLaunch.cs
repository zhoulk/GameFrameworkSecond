

using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.IO;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo18_procedureLaunch : ProcedureBase {

    DownloadComponent downloadComponent;
    EventComponent eventComponent;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架Event组件
        downloadComponent = GameEntry.GetComponent<DownloadComponent>();
        eventComponent = GameEntry.GetComponent<EventComponent>();

        eventComponent.Subscribe(DownloadUpdateEventArgs.EventId, OnDownloadUpdate);
        eventComponent.Subscribe(DownloadSuccessEventArgs.EventId, OnDownloadSuccess);

        string m_srcUrl = "http://cdn-jiaoyu-nldmx-yidong.vas.lutongnet.com/ggly_NLDMX/NLDMX_Mobile/android/GamePrimaryT6L4.ab";
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + "test.ab";
        int id = downloadComponent.AddDownload(path, m_srcUrl);
        Log.Info("start    " + id);
    }

    private void OnDownloadUpdate(object sender, GameEventArgs e)
    {
        DownloadUpdateEventArgs ne = (DownloadUpdateEventArgs)e;
        Log.Debug(ne.CurrentLength);
    }

    private void OnDownloadSuccess(object sender, GameEventArgs e)
    {
        DownloadSuccessEventArgs ne = (DownloadSuccessEventArgs)e;
        Log.Debug(ne.SerialId + "   " + ne.Id);
    }
}
