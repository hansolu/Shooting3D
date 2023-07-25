using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSingleton : MonoBehaviour
{    
    void Start()
    {
        //여기서 바로 부르면 에러뜸. 아직 만들어지지않았다~
        StartCoroutine(CheckSingletonCor());
                    
    }

    IEnumerator CheckSingletonCor()
    {
        yield return new WaitUntil(()=>TestSingleton1.Instance !=null);
        AA();
    }

    void AA()
    {
        Debug.Log("씬스크립트가 부르는 TestSingleton1 해시코드 : " + TestSingleton1.Instance.GetHashCode() + " / 값 : " + TestSingleton1.Instance.a);
        Debug.Log("씬스크립트가 부르는 TestSingleton2 해시코드 : " + TestSingleton2.Instance.GetHashCode() + " / 값 : " + TestSingleton2.Instance.a);
        Debug.Log("씬스크립트가 부르는 TestSingleton3 해시코드 : " + TestSingleton3.Instance.GetHashCode() + " / 값 : " + TestSingleton3.Instance.a);
        Debug.Log("씬스크립트가 부르는 TestSingleton4 해시코드 : " + TestSingleton4.Instance.GetHashCode() + " / 값 : " + TestSingleton4.Instance.a);
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
