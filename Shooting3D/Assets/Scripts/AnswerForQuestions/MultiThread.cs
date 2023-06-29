using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;

public class MultiThread : MonoBehaviour
{    
    void Start()
    {
        ForTestCheck();
        /*
        Debug.Log("����");
        //Task.Factory   :   Task��ü�� ����� �����ϵ��� ����.
        Task.Factory.StartNew(SimpleForVoid); // ���� ȣ��, ������ ������ ����
        Debug.Log("SimpleForVoid + ���丮 ��ŸƮ ��");

        //Task task2 = new Task(new Action(SimpleForVoid)); // Action �븮�� 
        //task2.Start(); // Task ������ ���� 

        //Task task3 = new Task(delegate { SimpleForVoid(15); });  // �븮�� 
        //task3.Start(); // Task ������ ����  

        //Task task4 = new Task(() => SimpleForVoid()); // ���ٽ� 
        //task4.Start(); // Task ������ ����  

        //Task task5 = new Task(() => { SimpleForVoid(12); }); // ���ٿ� �͸� �޼��� 
        //task5.Start(); // Task ������ ���� 

        //Task task6 = new Task(SimpleForVoid); // ���ٿ� �͸� �޼��� 
        //task6.Start(); // Task ������ ���� 

        //Task<double> taskdouble = new Task<double>(SimpleForDouble);
        //Debug.Log("taskdouble�� ����� :" + taskdouble.Result);

        //var taskdouble2 = new Task<double>(()=>SimpleForDouble(9)); 
        //Debug.Log("taskdouble2�� ����� :" + taskdouble2.Result);

        var taskdouble3 = Task.Factory.StartNew(() => SimpleForDouble(111));
        Debug.Log("taskdouble3�� ����� :" + taskdouble3.Result);

        //task2.Wait(); // Task�� ���� ������ ���  
        //Debug.Log("task2 ���� �����");
        //task3.Wait(); // Task�� ���� ������ ��� 
        //Debug.Log("task3 ���� �����");
        //task4.Wait(); // Task�� ���� ������ ��� 
        //Debug.Log("task4 ���� �����");
        //task5.Wait(); // Task�� ���� ������ ��� 
        //Debug.Log("task5 ���� �����");
        //task6.Wait(); // Task�� ���� ������ ��� 

        //Debug.Log("task6 ���� �����");

        //taskdouble.Wait(); // Task�� ���� ������ ��� 
        //Debug.Log("taskdouble ���� �����");
        
        //taskdouble2.Wait(); // Task�� ���� ������ ��� 
        //Debug.Log("taskdouble2 ���� �����");

        taskdouble3.Wait(); // Task�� ���� ������ ��� 
        Debug.Log("taskdouble3 �� ��ŸƮ�� ������");
        */
    }

    public void ForTestCheck()
    {
        Debug.Log("����");                

        //���ο� ������ ����.
        Task.Factory.StartNew(SimpleForVoid); // ���� ȣ��, ������ ������ ����
        Debug.Log("SimpleForVoid + ���丮 ��ŸƮ ��");


        //�� ���ο� ������ ����
        var taskdouble3 = Task.Factory.StartNew(() => SimpleForDouble(111));
        Debug.Log("taskdouble3�� ����� :" + taskdouble3.Result);

        //�⺻�� �Ǵ� ���� �����忡�� �ϴ� ����.
        double results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        //���ν����忡�� �� �� ��
        results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        //taskdouble3.Wait(); // Task�� ���� ������ ��� 
        Debug.Log("taskdouble3 �� ��ŸƮ�� ������");
    }

    void SimpleForVoid()
    {        
        Thread.Sleep(1000); //1�ʰ� ������.
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
