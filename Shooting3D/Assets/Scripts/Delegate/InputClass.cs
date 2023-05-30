using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClass : MonoBehaviour
{
    //이 인풋이 필요한 특수 클래스     

    public virtual void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //이 인풋이 필요한 특수 클래스의 실행해야하는 함수..
        }
    }
}

public class UIInput : InputClass
{
    public override void CheckKeys()
    {
        //요기에서만 해당되는 특별... 케이스..
        base.CheckKeys();
    }
}
     
