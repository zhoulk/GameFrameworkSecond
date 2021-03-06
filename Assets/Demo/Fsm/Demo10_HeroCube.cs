﻿using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo10_HeroCube : EntityLogic {

    private GameFramework.Fsm.IFsm<Demo10_HeroCube> m_HeroFsm;
    private FsmComponent Fsm = null;

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();

        Debug.Log(Fsm);

        /* 英雄的所有状态类 */
        FsmState<Demo10_HeroCube>[] heroStates = new FsmState<Demo10_HeroCube>[] {
            new Demo10_HeroIdleState (),
            new Demo10_HeroWalkState (),
        };

        /* 创建状态机 */
        m_HeroFsm = Fsm.CreateFsm<Demo10_HeroCube>(this, heroStates);

        /* 启动站立状态 */
        m_HeroFsm.Start<Demo10_HeroIdleState>();
    }

    protected internal override void OnHide(bool isShutdown, object userData)
    {
        base.OnHide(isShutdown, userData);

        Fsm.DestroyFsm<Demo10_HeroCube>();
    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        /* 旋转镜头，这个可以不用管，和状态机Demo没有太大关系 */
        float inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, inputHorizontal * 3, 0));
        }
    }

    /// <summary>
    /// 向前移动
    /// </summary>
    /// <param name="distance"></param>
    public void Forward(float distance)
    {
        transform.position += transform.forward * distance * 5;
    }
}
