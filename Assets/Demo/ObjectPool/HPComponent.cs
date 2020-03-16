using GameFramework;
using GameFramework.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class HPComponent : GameFrameworkComponent
{

    [SerializeField]
    private HPBarItem m_HPBarItemTemplate = null;

    [SerializeField]
    private Transform m_HPBarInstanceRoot = null;

    IObjectPool<HPBarItemObject> m_HPBarItemObjectPool;

    // Use this for initialization
    void Start () {
        //根据绝对路径设置与获取数据
        ObjectPoolComponent poolComponent = GameEntry.GetComponent<ObjectPoolComponent>();
        m_HPBarItemObjectPool =
            poolComponent.CreateSingleSpawnObjectPool<HPBarItemObject>("HPBarItem", 10);

        //HPBarItem hpBarItem = Instantiate(m_HPBarItemTemplate);
        //Transform transform = hpBarItem.GetComponent<Transform>();
        //transform.SetParent(m_HPBarInstanceRoot);
        //transform.localScale = Vector3.one;
        //m_HPBarItemObjectPool.Register(HPBarItemObject.Create(null), true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public HPBarItem ShowHP()
    {
        HPBarItem hpBarItem = null;
        HPBarItemObject hpBarItemObject = m_HPBarItemObjectPool.Spawn();
        if (hpBarItemObject != null)
        {
            hpBarItem = (HPBarItem)hpBarItemObject.Target;
        }
        else
        {
            hpBarItem = Instantiate(m_HPBarItemTemplate);
            Transform transform = hpBarItem.GetComponent<Transform>();
            transform.SetParent(m_HPBarInstanceRoot);
            transform.localScale = Vector3.one;
            m_HPBarItemObjectPool.Register(HPBarItemObject.Create(hpBarItem), true);
        }

        return hpBarItem;
    }

    public void HideHP(HPBarItem hpBarItem)
    {
        m_HPBarItemObjectPool.Unspawn(hpBarItem);
    }
}

public class HPBarItemObject : ObjectBase
{
    public static HPBarItemObject Create(object target)
    {
        HPBarItemObject hpBarItemObject = ReferencePool.Acquire<HPBarItemObject>();
        hpBarItemObject.Initialize(target);
        return hpBarItemObject;
    }

    protected internal override void Release(bool isShutdown)
    {
        HPBarItem hpBarItem = (HPBarItem)Target;
        if (hpBarItem == null)
        {
            return;
        }

        Object.Destroy(hpBarItem.gameObject);
    }
}
