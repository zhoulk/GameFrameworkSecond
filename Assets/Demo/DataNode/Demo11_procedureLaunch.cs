using GameFramework;
using GameFramework.DataNode;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo11_procedureLaunch : ProcedureBase {

    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        //根据绝对路径设置与获取数据
        DataNodeComponent dataComponent = GameEntry.GetComponent<DataNodeComponent>();
        VarString var1 = new VarString();
        var1.SetValue("Ellan");
        dataComponent.SetData <VarString> ("Player.Name", var1);
        string playerName = dataComponent.GetData<LocalVariable<string>>("Player.Name").Value;
        Log.Info(playerName);

        //根据相对路径设置与获取数据
        IDataNode playerNode = dataComponent.GetNode("Player");
        VarInt var2 = new VarInt();
        var2.SetValue(99);
        dataComponent.SetData<VarInt>("Level", var2, playerNode);
        int playerLevel = dataComponent.GetData<VarInt>("Level", playerNode).Value;
        Log.Info(playerLevel);

        //直接通过数据结点来操作
        VarInt var3 = new VarInt();
        var3.SetValue(1000);
        IDataNode playerExpNode = playerNode.GetOrAddChild("Exp");
        playerExpNode.SetData(var3);
        int playerExp = playerExpNode.GetData<VarInt>().Value;
        Log.Info(playerExp);
    }
}

class LocalVariable<T> : Variable<T>
{

}

