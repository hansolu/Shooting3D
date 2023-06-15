using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditShader : MonoBehaviour
{
    MeshRenderer render; //자기 메시렌더러

    void Start()
    {
        render = GetComponent<MeshRenderer>();        
    }
    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Alpha1))
    //    //{
    //    //    SetCount(1);
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    //{
    //    //    SetCount(2);
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.Alpha3))
    //    //{
    //    //    SetCount(3);
    //    //}
    //    Debug.Log(Time.time);
    //    SetCount(Time.time);
    //}

    
    public void SetCount(float val)
    {
        render.material.SetFloat("_X", val);        
    }
}
