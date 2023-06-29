using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSimple : MonoBehaviour
{
    float speed = 5;
    public Vector3 vec = Vector3.zero;
    //Quaternion rotquat;
    float rotval = 3;
    float x, z = 0;
    public void AA()
    { }

    protected void BB()
    { }

    void CC()
    {
        
    }
    void FixedUpdate()
    {        
        x = Input.GetAxis("Horizontal"); //옆 회전.
        z = Input.GetAxisRaw("Vertical"); //앞뒤 이동                
        vec.z = z;
        vec.x = x;
        transform.Translate(vec * speed * Time.deltaTime);

        return;
        
        //transform.Rotate(Vector3.up * speed * x);
        if (x!=0)
        {
            //rotquat = Quaternion.LookRotation(vec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotquat, speed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotval * x);
        }        
    }
}
