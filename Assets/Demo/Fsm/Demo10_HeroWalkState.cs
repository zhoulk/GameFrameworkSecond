using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo10_HeroWalkState : FsmState<Demo10_HeroCube>
{

    /// <summary>
    /// 有限状态机状态初始化时调用。
    /// </summary>
    /// <param name="fsm">有限状态机引用。</param>
    protected internal override void OnInit(IFsm<Demo10_HeroCube> fsm) {
        Log.Info("进入行走状态");
    }

    /// <summary>
    /// 有限状态机状态进入时调用。
    /// </summary>
    /// <param name="fsm">有限状态机引用。</param>
    protected internal override void OnEnter(IFsm<Demo10_HeroCube> fsm)
    {
        Log.Info("进入行走状态");
    }

    /// <summary>
    /// 有限状态机状态轮询时调用。
    /// </summary>
    /// <param name="fsm">有限状态机引用。</param>
    /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
    /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
    protected internal override void OnUpdate(IFsm<Demo10_HeroCube> fsm, float elapseSeconds, float realElapseSeconds)
    {
        float inputVertical = Input.GetAxis("Vertical");
        if (inputVertical != 0)
        {
            /* 移动 */
            fsm.Owner.Forward(elapseSeconds * inputVertical);
        }
        else
        {
            /* 站立 */
            ChangeState<Demo10_HeroIdleState>(fsm);
        }
    }
}
