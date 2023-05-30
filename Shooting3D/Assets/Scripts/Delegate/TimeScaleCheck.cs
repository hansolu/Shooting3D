using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeScaleCheck : MonoBehaviour
{
    float timescale = 1;
    WaitForSecondsRealtime realtime = new WaitForSecondsRealtime(0.1f);
    WaitForSeconds time = new WaitForSeconds(0.1f);
    void Start()
    {
        //Time.timeScale = 2;  //2배속
        //Time.timeScale = 0.5f; //0.5배속 
        //Time.timeScale = 1; //일반상태

        timescale = 1;
        StartCoroutine(Coroutine());
        StartCoroutine(Coroutine_Real());
    }
    void Update()//TimeScale영향 x
    {
        if (timescale ==0 /*일시정지를 눌렀는지 여부 bool*/)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            timescale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            timescale = 0;
        }

        Debug.Log("Update 도는중" + timescale);
        Time.timeScale = 0;//timescale;
    }
    void FixedUpdate() //타임스케일 영향받음
    {
        //타임스케일이 0일경우 돌지않음....
        Debug.Log("Fixed Update 도는중");
    }
    void LateUpdate()//TimeScale영향 x
    {
        //타임스케일이 0이어도 돌음
        Debug.Log("LateUpdate 도는중");
    }

    IEnumerator Coroutine() //타임스케일 영향받음
    {
        while (true)
        {
            Debug.Log("그냥 코루틴 도는중");
            yield return time;//new WaitForSeconds(0.1f);
        }        
    }

    IEnumerator Coroutine_Real() //TimeScale영향 x.
    {
        while (true)
        {
            Debug.Log("리얼타임 코루틴 도는중");
            yield return realtime;//new WaitForSecondsRealtime(0.1f);
        }
    }
}
