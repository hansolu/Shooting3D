using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClass : MonoBehaviour
{
    //�� ��ǲ�� �ʿ��� Ư�� Ŭ����     

    public virtual void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //�� ��ǲ�� �ʿ��� Ư�� Ŭ������ �����ؾ��ϴ� �Լ�..
        }
    }
}

public class UIInput : InputClass
{
    public override void CheckKeys()
    {
        //��⿡���� �ش�Ǵ� Ư��... ���̽�..
        base.CheckKeys();
    }
}
     
