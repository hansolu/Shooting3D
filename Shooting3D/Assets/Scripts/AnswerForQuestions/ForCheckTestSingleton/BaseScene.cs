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

    //�� ������ ���������� �����ؾ��ϴ� ���׵�...
    SceneName sceneName;
    public SceneName SceneName => sceneName;

    public void CommonFunc()
    {
        Debug.Log("�� ������ �ϰ� ���� ����");
    }
    
}
