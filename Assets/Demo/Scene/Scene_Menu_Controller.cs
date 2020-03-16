using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Scene_Menu_Controller : MonoBehaviour {

	public void OnBtnClick()
    {
        SceneComponent scene
            = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        // 卸载所有场景
        string[] loadedSceneAssetNames = scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            scene.UnloadScene(loadedSceneAssetNames[i]);
        }

        scene.LoadScene("Assets/Demo/Scene/sceneGame.unity", this);
    }
}
