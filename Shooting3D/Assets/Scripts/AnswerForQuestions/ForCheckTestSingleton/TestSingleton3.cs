using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton3 : SingletonMono<TestSingleton3>
{
    public Material mat;
    void Start()
    {
        if (transform.childCount > 0 && transform.GetChild(0)!=null) //안하면 에러
        {
            if (transform.GetChild(0).GetComponent<MeshRenderer>()!=null)
            {
                mat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
            }
        }
        
        
        Debug.Log("TestSingleton3 해시코드 : " + GetHashCode() + " / 값" + a);        
    }
    public int a = 0;
    public override int GetHashCode()
    {
        a++;
        SetMatColor();
        return base.GetHashCode();
    }

    public void SetMatColor()
    {
        if (mat == null)
        {
            Debug.Log(a + " 테스트 싱글톤3의 mat은 비었음");
            return;
        }
        
            if (a <= 2)
            {
                mat.color = Color.green;
            }
            else if (a <= 4)
            {
                mat.color = Color.blue;
            }
            else
            {
                mat.color = Color.red;
            }
        
    }
}
