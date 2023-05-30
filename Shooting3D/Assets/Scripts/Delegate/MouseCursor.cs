using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random; //유니티 제공 random이 아닌 시스템 랜덤사용할경우.

public class MouseCursor : MonoBehaviour
{
    bool isOn = true;
    void Start()
    {
        //Random ran = new Random();        
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            if (isOn )
            {
                isOn = false;                
            }
            else
            {
                isOn = true;                
            }

            Cursor.visible = isOn;
        } 
    }
}
