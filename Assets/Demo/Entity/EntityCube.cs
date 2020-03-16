using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class EntityCube : EntityLogic {

    protected internal override void OnShow(object userData)
    {
        base.OnShow(userData);
        Log.Debug("Cube is show");
    }
}
