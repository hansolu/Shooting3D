using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Input.anyKey //�Ű�� ������ �ִ���
        //Input.anyKeyDown //� Ű�� ���ȴ���

        Debug.Log("�α�");
        Debug.LogWarning("�α� ���");
        Debug.LogError(" Ȯ���ϰ� ���� ���� ");  //�𺧷ӹ������� ���� + script debugging üũ ������ ����׷� ��������
    }
}
