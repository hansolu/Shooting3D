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
            Debug.Log(i+"번째 결과값 "+results);
        }
        Debug.Log("마지막 결과값: "+results);
        return results;
    }
}
