
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class EntityDemo : MonoBehaviour {

    bool isExcute = false;
    private void Update()
    {
        if (!isExcute)
        {
            isExcute = true;
            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            entityComponent.ShowEntity<EntityCube>(1, "Assets/Demo/Entity/Cube.prefab", "cubes");
        }
    }
}
