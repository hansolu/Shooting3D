using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSingleton : MonoBehaviour
{    
    void Start()
    {
        //���⼭ �ٷ� �θ��� ������. ���� ����������ʾҴ�~
        StartCoroutine(CheckSingletonCor());
                    
    }

    IEnumerator CheckSingletonCor()
    {
        yield return new WaitUntil(()=>TestSingleton1.Instance !=null);
        AA();
    }

    void AA()
    {
        Debug.Log("����ũ��Ʈ�� �θ��� TestSingleton1 �ؽ��ڵ� : " + TestSingleton1.Instance.GetHashCode() + " / �� : " + TestSingleton1.Instance.a);
        Debug.Log("����ũ��Ʈ�� �θ��� TestSingleton2 �ؽ��ڵ� : " + TestSingleton2.Instance.GetHashCode() + " / �� : " + TestSingleton2.Instance.a);
        Debug.Log("����ũ��Ʈ�� �θ��� TestSingleton3 �ؽ��ڵ� : " + TestSingleton3.Instance.GetHashCode() + " / �� : " + TestSingleton3.Instance.a);
        Debug.Log("����ũ��Ʈ�� �θ��� TestSingleton4 �ؽ��ڵ� : " + TestSingleton4.Instance.GetHashCode() + " / �� : " + TestSingleton4.Instance.a);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Test006_ForCheckSingleton2"))
            {
                SceneManager.LoadScene("Test006_ForCheckSingleton");
            }
            else
                SceneManager.LoadScene("Test006_ForCheckSingleton2");
        }
    }
}
