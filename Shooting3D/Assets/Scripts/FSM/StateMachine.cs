using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StateKindEnum
{
    공격1,    
    공격2,
    공격3,
    스킬1,
    스킬2,    
    스킬3,
    스킬4,
    스킬5,
    스킬6
}

public enum StateEnum //Kind Enum //크게 내가 그냥인지 공격중인지 죽엇는지 살앗는지..
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
    //패턴은 아무래도 원본패턴과 한바퀴 돌릴 Queue로 만든 패턴..정도..
    List<StateEnum> patternState = new List<StateEnum>(); //행동패턴.. 설정해둠
    List<StateEnum> reserveState = new List<StateEnum>();//다음 스테이트 예약을 걸고 싶다면.

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
        //일정시간동안 너무 오래 Idle이었으면
        //걍 강제로 Move해버리고싶음..
        //혹은 패턴에 따른 진행하고 싶음
        //StateDic[patternState[actnum]].OnStateExit();
        //actnum++;
        //StateDic[patternState[actnum]].OnStateEnter();  ; //actnum에 따른 다음 패턴 적용

        //혹은
        if (enemy.ex_State != enemy.nowState) //enemy의 상태가 바뀌어서
        {
            //바뀐 상태를 적용시켜 주겠음
            StateDic[enemy.ex_State].OnStateExit();
            StateDic[enemy.nowState].OnStateEnter();
            enemy.ex_State = enemy.nowState;
        }
    }

    //밖에서 강제로 상태 바꿔줘 하는것.
    public void SetState(StateEnum _enum)
    {
        if (enemy.nowState!=_enum)
        {
            //바뀐 상태를 적용시켜 주겠음
            StateDic[enemy.ex_State].OnStateExit();
            StateDic[enemy.nowState].OnStateEnter();
            enemy.ex_State = enemy.nowState;

            ////if (_cor !=null ) //새로운 상태가 들어온다면 무조건 그 최신 상태를 다음으로 쓸 것
            ////{
            ////    StopCoroutine(_cor);                
            ////}
            //if(_cor ==null) //무조건 예약되어있지 않은 그 한번만
            //_cor =StartCoroutine(SetNextState(_enum));
        }
    }

    //IEnumerator SetNextState(StateEnum _enum)
    //{
    //    //OnStateExit가 조건이 맞아야 끝나길 바라서 Bool을 반환한다면 이렇게도 가능.
    //    yield return new WaitUntil(
    //        () => StateDic[enemy.nowState].OnStateExit());

    //    enemy.nowState = _enum;
    //    StateDic[enemy.nowState].OnStateEnter();

    //    _cor = null;
    //}
}
