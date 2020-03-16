using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

public class Demo4_ProcedureMenu : ProcedureBase {
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 加载框架UI组件
        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        // 加载框架Event组件
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();

        // 加载UI

        // 订阅UI加载成功事件
        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        UI.OpenUIForm("Assets/Demo/Event/UI_Menu.prefab", "DefaultGroup", this);
    }

    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        // 判断userData是否为自己
        if (ne.UserData != this)
        {
            return;
        }
        Log.Debug(ne.UserData + "UI_Menu：恭喜你，成功地召唤了我。");
    }
}
