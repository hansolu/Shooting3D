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
        //Time.timeScale = 2;  //2���
        //Time.timeScale = 0.5f; //0.5��� 
        //Time.timeScale = 1; //�Ϲݻ���

        timescale = 1;
        StartCoroutine(Coroutine());
        StartCoroutine(Coroutine_Real());
    }
    void Update()//TimeScale���� x
    {
        if (timescale ==0 /*�Ͻ������� �������� ���� bool*/)
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

        Debug.Log("Update ������" + timescale);
        Time.timeScale = 0;//timescale;
    }
    void FixedUpdate() //Ÿ�ӽ����� �������
    {
        //Ÿ�ӽ������� 0�ϰ�� ��������....
        Debug.Log("Fixed Update ������");
    }
    void LateUpdate()//TimeScale���� x
    {
        //Ÿ�ӽ������� 0�̾ ����
        Debug.Log("LateUpdate ������");
    }

    IEnumerator Coroutine() //Ÿ�ӽ����� �������
    {
        while (true)
        {
            Debug.Log("�׳� �ڷ�ƾ ������");
            yield return time;//new WaitForSeconds(0.1f);
        }        
    }

    IEnumerator Coroutine_Real() //TimeScale���� x.
    {
        while (true)
        {
            Debug.Log("����Ÿ�� �ڷ�ƾ ������");
            yield return realtime;//new WaitForSecondsRealtime(0.1f);
        }
    }
}
