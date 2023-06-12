using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform rotateObj; //주변을 돌게 할 물체

    Vector3 vec = Vector3.zero; //임시변수
    float x, z = 0; //임시변수    


    float radius = 3; //도는 반지름
    float degree = 0; //회전할 각도
    float rad = 0; //각도계산2
    float speed = 20; //회전 속도    
    

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
