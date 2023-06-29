using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;

public class MultiThread_1 : MonoBehaviour
{    
    void Start()
    {
        ForTestCheck();
    }
    public void ForTestCheck()
    {
        Debug.Log("시작");
        double results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        
        SimpleForVoid(); //단순 함수 콜링.
        Debug.Log("SimpleForVoid + 팩토리 스타트 뉴");

        double taskdouble3 = SimpleForDouble(111);
        Debug.Log("taskdouble3의 결과값 :" + taskdouble3);

        results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        Debug.Log("taskdouble3 끝 스타트의 마지막");
    }

    void SimpleForVoid()
    {
        Thread.Sleep(1000);
        double results = 0;
        for (int i = 0; i < 100; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);
    }
    void SimpleForVoid(int val)
    {
        Thread.Sleep(1000);
        double results = 0;
        for (int i = 0; i < val; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid 매개변수 있는 : " + results);
    }

    double SimpleForDouble()
    {
        Thread.Sleep(1000);
        double results = 0;
        for (int i = 0; i < 10; i++)
        {
            results += i;
        }
        
        Debug.Log("SimpleForDouble  : " + results);
        return results;
    }
    double SimpleForDouble(int val)
    {
        Thread.Sleep(1000);
        double results = 0;
        for (int i = 0; i < val; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForDouble 매개변수 있는 : " + results);        
        return results;
    }
}
