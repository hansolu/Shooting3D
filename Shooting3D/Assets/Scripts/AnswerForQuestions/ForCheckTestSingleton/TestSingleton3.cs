using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton3 : SingletonMono<TestSingleton3>
{
    public Material mat;
    void Start()
    {
        if (transform.childCount > 0 && transform.GetChild(0)!=null) //���ϸ� ����
        {
            if (transform.GetChild(0).GetComponent<MeshRenderer>()!=null)
            {
                mat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
            }
        }
        
        
        Debug.Log("TestSingleton3 �ؽ��ڵ� : " + GetHashCode() + " / ��" + a);        
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
            Debug.Log(a + " �׽�Ʈ �̱���3�� mat�� �����");
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
