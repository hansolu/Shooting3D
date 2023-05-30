using UnityEngine;
using Singleton;
using System;
using System.Collections.Generic;

public class InputManager : SingletonMono<InputManager>
{
    delegate void DAction();
    
    //delegate int Delegate_int(); //int �Լ��̸�();
    //delegate float Delegate_float(); //float �Լ��̸�();

    //Func<�Ű�����1, �Ű�����2,.....  , int> //int �Լ��̸�(�Ű�����1,�Ű�����2...)

    //1�� ���̽�
    Dictionary<KeyCode, Action/*DAction*/> KeyActions = new Dictionary<KeyCode, Action>();
       

    public void AddFunction(KeyCode _key, Action _action)
    {        
        //�Ǻ��ؼ�.. 
        if (KeyActions.ContainsKey(_key)) //�̹�����
        {
            //�̹�������� ��� �Ұ�����
            //KeyActions[_key] += �Լ�;
        }
        else
            KeyActions.Add(_key, _action);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (KeyActions.ContainsKey(KeyCode.A))
            {
                KeyActions[KeyCode.A]();
            }
            
        }   
    }

    //=============================

    ////2�����̽�
    //InputClass input;
    //enum UICase { Minigame,UI, Default}
    //public void SetInputMode(UICase _case)
    //{
    //    switch (_case)
    //    {
    //        case UICase.Minigame:
    //            input = new MiniGameInput();
    //            break;
    //        case UICase.UI:
    //            input = new UIInput();
    //            break;
    //        default:
    //            input = new InputClass();
    //            break;
    //    }
    //}

    //void Update()
    //{
    //    input.CheckKeys();
    //}
}
