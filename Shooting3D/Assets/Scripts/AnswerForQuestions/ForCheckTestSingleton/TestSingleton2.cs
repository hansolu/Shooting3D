using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton2 : Singleton<TestSingleton2> 
{    
    void Start()
    {        
        Debug.Log(a + "TestSingleton2 �ܼ��̱����ؽ��ڵ� : " + GetHashCode() + " / ��" + a);
        
    }

    public int a = 0;
    public override int GetHashCode()
    {        
        a++;        
        return base.GetHashCode();
    } 
    
}
