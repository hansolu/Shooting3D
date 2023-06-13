using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorque : MonoBehaviour
{
    Rigidbody rigid;
    Vector2 dir;
    float x, y = 0;
    public float power = 2;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        x = Screen.width * 0.5f;
        y = Screen.height * 0.5f;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            dir.x = Input.mousePosition.x - x;
            dir.y = Input.mousePosition.y - y;
            dir.Normalize();
            Debug.Log(dir);
            rigid.AddTorque( dir * power); 
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddTorque(Vector3.down * power); //해당축 기준으로 회전시킴
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddTorque(Vector3.up * power); //해당축 기준으로 회전시킴
        }
    }
}
