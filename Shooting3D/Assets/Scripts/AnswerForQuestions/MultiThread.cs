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
        Debug.Log("시작");
        //Task.Factory   :   Task객체를 만들고 예약하도록 지원.
        Task.Factory.StartNew(SimpleForVoid); // 직접 호출, 스레드 생성과 시작
        Debug.Log("SimpleForVoid + 팩토리 스타트 뉴");

        //Task task2 = new Task(new Action(SimpleForVoid)); // Action 대리자 
        //task2.Start(); // Task 스레드 시작 

        //Task task3 = new Task(delegate { SimpleForVoid(15); });  // 대리자 
        //task3.Start(); // Task 스레드 시작  

        //Task task4 = new Task(() => SimpleForVoid()); // 람다식 
        //task4.Start(); // Task 스레드 시작  

        //Task task5 = new Task(() => { SimpleForVoid(12); }); // 람다와 익명 메서드 
        //task5.Start(); // Task 스레드 시작 

        //Task task6 = new Task(SimpleForVoid); // 람다와 익명 메서드 
        //task6.Start(); // Task 스레드 시작 

        //Task<double> taskdouble = new Task<double>(SimpleForDouble);
        //Debug.Log("taskdouble의 결과값 :" + taskdouble.Result);

        //var taskdouble2 = new Task<double>(()=>SimpleForDouble(9)); 
        //Debug.Log("taskdouble2의 결과값 :" + taskdouble2.Result);

        var taskdouble3 = Task.Factory.StartNew(() => SimpleForDouble(111));
        Debug.Log("taskdouble3의 결과값 :" + taskdouble3.Result);

        //task2.Wait(); // Task가 끝날 때까지 대기  
        //Debug.Log("task2 다음 디버그");
        //task3.Wait(); // Task가 끝날 때까지 대기 
        //Debug.Log("task3 다음 디버그");
        //task4.Wait(); // Task가 끝날 때까지 대기 
        //Debug.Log("task4 다음 디버그");
        //task5.Wait(); // Task가 끝날 때까지 대기 
        //Debug.Log("task5 다음 디버그");
        //task6.Wait(); // Task가 끝날 때까지 대기 

        //Debug.Log("task6 다음 디버그");

        //taskdouble.Wait(); // Task가 끝날 때까지 대기 
        //Debug.Log("taskdouble 다음 디버그");
        
        //taskdouble2.Wait(); // Task가 끝날 때까지 대기 
        //Debug.Log("taskdouble2 다음 디버그");

        taskdouble3.Wait(); // Task가 끝날 때까지 대기 
        Debug.Log("taskdouble3 끝 스타트의 마지막");
        */
    }

    public void ForTestCheck()
    {
        Debug.Log("시작");                

        //새로운 스레드 열음.
        Task.Factory.StartNew(SimpleForVoid); // 직접 호출, 스레드 생성과 시작
        Debug.Log("SimpleForVoid + 팩토리 스타트 뉴");


        //또 새로운 스레드 열음
        var taskdouble3 = Task.Factory.StartNew(() => SimpleForDouble(111));
        Debug.Log("taskdouble3의 결과값 :" + taskdouble3.Result);

        //기본이 되는 메인 스레드에서 하는 뭔가.
        double results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        //메인스레드에서 할 거 함
        results = 0;
        for (int i = 0; i < 1000; i++)
        {
            results += i;
        }
        Debug.Log("SimpleForVoid : " + results);

        //taskdouble3.Wait(); // Task가 끝날 때까지 대기 
        Debug.Log("taskdouble3 끝 스타트의 마지막");
    }

    void SimpleForVoid()
    {        
        Thread.Sleep(1000); //1초간 쉬겠음.
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
