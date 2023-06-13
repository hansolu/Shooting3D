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
        degree += Time.deltaTime * speed; //프레임당시간 * 속도
        if (degree<360) 
        {
            rad = Mathf.Deg2Rad * degree; //sin, cos는 라디안 단위이기 떄문에 일반 각도 에서 라디안으로 바꾼 값이 필요함
            x = radius * Mathf.Sin(rad); 
            z = radius * Mathf.Cos(rad);
            vec.x = x;
            vec.z = z;
            rotateObj.transform.position = transform.position + vec; //주가 되는 것의 위치  + 주가되는 것의 위치로부터 반지름만큼 떨어져있고
                                                                     //원 위의 위치에 해당되는 값으로 계속 업데이트 해줌
            rotateObj.transform.rotation = Quaternion.Euler(90, degree, 0); //눕히기 위해서 x로 90도 돌리고,
                                                                            //누워있는상태이기 떄문에 y값을 degree만큼 돌려줌.
        }
        else
        {
            degree = 0; //360도 이상이 된다면 0도로 초기화해줌
        }        
    }
}
