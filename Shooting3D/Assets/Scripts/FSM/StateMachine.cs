using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StateKindEnum
{
    ����1,    
    ����2,
    ����3,
    ��ų1,
    ��ų2,    
    ��ų3,
    ��ų4,
    ��ų5,
    ��ų6
}

public enum StateEnum //Kind Enum //ũ�� ���� �׳����� ���������� �׾����� ��Ѵ���..
{
    None,
    Idle,
    Attack,

    Die
}

public class StateMachine : MonoBehaviour
{    
    public Enemy enemy;

    int actnum = 0;
    //������ �ƹ����� �������ϰ� �ѹ��� ���� Queue�� ���� ����..����..
    List<StateEnum> patternState = new List<StateEnum>(); //�ൿ����.. �����ص�
    List<StateEnum> reserveState = new List<StateEnum>();//���� ������Ʈ ������ �ɰ� �ʹٸ�.

    //
    Dictionary<StateEnum, State> StateDic = new Dictionary<StateEnum, State>();

    Coroutine _cor = null;
    public StateMachine(Enemy _enemy
        /*, Dictionary<StateEnum, State> _dic*/)
    {
        enemy = _enemy;
        //foreach (var item in _dic)
        //{
        //    StateDic.Add(item.Key, item.Value);
        //}
        _cor = null;
    }

    void Update()
    {
        //�����ð����� �ʹ� ���� Idle�̾�����
        //�� ������ Move�ع��������..
        //Ȥ�� ���Ͽ� ���� �����ϰ� ����
        //StateDic[patternState[actnum]].OnStateExit();
        //actnum++;
        //StateDic[patternState[actnum]].OnStateEnter();  ; //actnum�� ���� ���� ���� ����

        //Ȥ��
        if (enemy.ex_State != enemy.nowState) //enemy�� ���°� �ٲ�
        {
            //�ٲ� ���¸� ������� �ְ���
            StateDic[enemy.ex_State].OnStateExit();
            StateDic[enemy.nowState].OnStateEnter();
            enemy.ex_State = enemy.nowState;
        }
    }

    //�ۿ��� ������ ���� �ٲ��� �ϴ°�.
    public void SetState(StateEnum _enum)
    {
        if (enemy.nowState!=_enum)
        {
            //�ٲ� ���¸� ������� �ְ���
            StateDic[enemy.ex_State].OnStateExit();
            StateDic[enemy.nowState].OnStateEnter();
            enemy.ex_State = enemy.nowState;

            ////if (_cor !=null ) //���ο� ���°� ���´ٸ� ������ �� �ֽ� ���¸� �������� �� ��
            ////{
            ////    StopCoroutine(_cor);                
            ////}
            //if(_cor ==null) //������ ����Ǿ����� ���� �� �ѹ���
            //_cor =StartCoroutine(SetNextState(_enum));
        }
    }

    //IEnumerator SetNextState(StateEnum _enum)
    //{
    //    //OnStateExit�� ������ �¾ƾ� ������ �ٶ� Bool�� ��ȯ�Ѵٸ� �̷��Ե� ����.
    //    yield return new WaitUntil(
    //        () => StateDic[enemy.nowState].OnStateExit());

    //    enemy.nowState = _enum;
    //    StateDic[enemy.nowState].OnStateEnter();

    //    _cor = null;
    //}
}
