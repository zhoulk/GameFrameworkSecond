using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityGameFramework.Runtime;
using NetworkConnectedEventArgs = UnityGameFramework.Runtime.NetworkConnectedEventArgs;

public class Demo8_procedureLauncher : ProcedureBase {

    public static bool isClose = false;
    private GameFramework.Network.INetworkChannel m_Channel;
    private NetworkChannelHelper m_NetworkChannelHelper;

    private float time = 0;

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 获取框架事件组件
        EventComponent Event
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();

        Event.Subscribe(NetworkConnectedEventArgs.EventId, OnConnected);

        // 获取框架网络组件
        NetworkComponent Network
            = UnityGameFramework.Runtime.GameEntry.GetComponent<NetworkComponent>();

        // 创建频道
        m_NetworkChannelHelper = new NetworkChannelHelper();
        m_Channel = Network.CreateNetworkChannel("testName", ServiceType.Tcp, m_NetworkChannelHelper);

        // 连接服务器
        m_Channel.Connect(IPAddress.Parse("127.0.0.1"), 8098);
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
    }

    private void OnConnected(object sender, GameEventArgs e)
    {
        NetworkConnectedEventArgs ne = (NetworkConnectedEventArgs)e;

        // 发送消息给服务端
        //m_Channel.Send(new CSHello()
        //{
        //    Name = "服务器你好吗？",
        //});
    }
}
