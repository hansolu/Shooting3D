using UnityEngine;
using Singleton;
using System;
using System.Collections.Generic;

public class InputManager : SingletonMono<InputManager>
{
    delegate void DAction();
    
    //delegate int Delegate_int(); //int 함수이름();
    //delegate float Delegate_float(); //float 함수이름();

    //Func<매개변수1, 매개변수2,.....  , int> //int 함수이름(매개변수1,매개변수2...)

    //1번 케이스
    Dictionary<KeyCode, Action/*DAction*/> KeyActions = new Dictionary<KeyCode, Action>();
       

    public void AddFunction(KeyCode _key, Action _action)
    {        
        //판별해서.. 
        if (KeyActions.ContainsKey(_key)) //이미있음
        {
            //이미있을경우 어떻게 할것인지
            //KeyActions[_key] += 함수;
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

    ////2번케이스
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
