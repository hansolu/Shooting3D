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
        Debug.Log("����");
        double results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        
        SimpleForVoid(); //�ܼ� �Լ� �ݸ�.
        Debug.Log("SimpleForVoid + ���丮 ��ŸƮ ��");

        double taskdouble3 = SimpleForDouble(111);
        Debug.Log("taskdouble3�� ����� :" + taskdouble3);

        results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        Debug.Log("taskdouble3 �� ��ŸƮ�� ������");
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
        Debug.Log("SimpleForVoid �Ű����� �ִ� : " + results);
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
        Debug.Log("SimpleForDouble �Ű����� �ִ� : " + results);        
        return results;
    }
}
