using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform rotateObj; //�ֺ��� ���� �� ��ü

    Vector3 vec = Vector3.zero; //�ӽú���
    float x, z = 0; //�ӽú���    


    float radius = 3; //���� ������
    float degree = 0; //ȸ���� ����
    float rad = 0; //�������2
    float speed = 20; //ȸ�� �ӵ�    
    

    void Update()
    {
        degree += Time.deltaTime * speed;
        if (degree<360)
        {
            rad = Mathf.Deg2Rad * degree;
            x = radius * Mathf.Sin(rad);
            z = radius * Mathf.Cos(rad);
            vec.x = x;
            vec.z = z;
            rotateObj.transform.position = transform.position + vec;
            rotateObj.transform.rotation = Quaternion.Euler(90, degree, 0);
        }
        else
        {
            degree = 0;
        }        
    }
}
