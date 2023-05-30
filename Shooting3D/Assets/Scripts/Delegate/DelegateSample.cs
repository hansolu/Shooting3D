using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    public enum EOperator
    {
        PLUS,
        MINUS,
        MULTI,
        DIVIDE,

        END
    }

    public class Mathematics
    {
        public delegate int CalDelegate(int x, int y); //int �Լ��̸�(�Ű����� int1, �Ű����� int 2)
        //CalDelegate[] delArr;

        Dictionary<EOperator, CalDelegate> delDic = new Dictionary<EOperator, CalDelegate>();

        public Mathematics()
        {
            //delArr = new CalDelegate[] { Plus, Minus, Multiply, Divide };
            delDic.Add(EOperator.PLUS, Plus);
            delDic.Add(EOperator.MINUS, Minus);
            delDic.Add(EOperator.MULTI, Multiply);
            delDic.Add(EOperator.DIVIDE, Divide);
        }
        public void Calculate(/*char coper,*/ EOperator _oper, int x, int y)
        {            
            Debug.Log(
                delDic[_oper](x, y)
                );

            //�迭 ����� ����
            
            //switch (coper)
            //{
            //    case '+':
            //      Debug.Log( delArr[0](x, y));
            //        break;
            //    case '-':
            //        Debug.Log(delArr[1](x, y));
            //        break;
            //    case '/':
            //        Debug.Log(delArr[2](x, y));
            //        break;
            //    case '*':
            //        Debug.Log(delArr[3](x, y));
            //        break;
            //    default:                
            //        break;
            //}            
        }

        public int Plus(int x, int y)
        {
            int val = x + y;
            Debug.Log($"{x}���ϱ�{y} : " + val);
            return val;
        }
        public int Minus(int x, int y)
        {
            int val = x - y;
            Debug.Log($"{x}����{y} : " + val);
            return val;
        }
        public int Multiply(int x, int y)
        {
            int val = x * y;
            Debug.Log($"{x}���ϱ�{y} : " + val);
            return val;
        }
        public int Divide(int x, int y)
        {
            int val = x / y;
            Debug.Log($"{x}������{y} : " + val);
            return val;
        }
    }


    /// <summary>
    /// //
    /// </summary>
    /// <param name="_code"></param>
    /// <param name="_action"></param>
    public delegate void DActionKey(KeyCode _code, Action _action);


    public Action BB()
    {
        //�ҰŴ��ϰ�~
        return CC;
    }

    public void CC()
    {
        DD(KeyCode.B, EE);
    }

    public DActionKey DD(KeyCode _key, Action _action)
    {
        //�Ұ��ϰ�~~

        return AddFunction;
    }
    public void EE()
    {
    }

    public void AddFunction(KeyCode _key, Action _action)
    {        
    }
}
