using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{ 
    Scene1,
    Scene2
}
public class BaseScene : MonoBehaviour
{
    public GameObject SceneObject;
    public GameObject[] SceneObjects;

    //각 씬마다 공통적으로 존재해야하는 사항들...
    SceneName sceneName;
    public SceneName SceneName => sceneName;

    public void CommonFunc()
    {
        Debug.Log("이 씬에서 하고 싶은 무언가");
    }
    
}
