using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton1 : SingletonMono<TestSingleton1>
{
    public Material mat;

    void Start()
    {
        mat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        Debug.Log("TestSingleton1 해시코드 : " + GetHashCode() +" / 값" +a);
        
    }
    public  int a = 0;
    public override int GetHashCode()
    {
        a++;
        SetMatColor();
        return base.GetHashCode();
    }

    public void SetMatColor()
    {
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
