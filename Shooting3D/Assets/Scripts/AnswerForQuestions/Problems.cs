using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problems : MonoBehaviour
{    
    public int TestVal(int aa)
    {
        int results = 0;
        for (int i = 1; i <= aa ; i++)
        {
            results += i;
            Debug.Log(i+"��° ����� "+results);
        }
        Debug.Log("������ �����: "+results);
        return results;
    }
}
