using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    public State_Idle(Enemy _enemy) : base(_enemy)
    {
        //enemy = _enemy;
    }

    public override void OnStateEnter()
    {
        enemy.Anim.Idle(true); //Idle 모션 시작해라
    }
    

    public override void OnStateStay()
    {
        //일정시간마다 걸어다니게 하고싶던지 뭔가 하고싶은것...
        //기능구현...

        //사람판별하고싶음..
        //사람위치 혹은 사람의 레이어...같은ㅇ거        
        //플레이어 .. 감지.. 
        //enemy.transform.position //Enemy정보에 접근 가능.
        //if (플레이어 감지 /*플레이어가 매니저에 들어있어서 매니저로 접근하거나
        // 플레이어 감지 기능을 Enemy스크립트 안에다 넣어두면 됨*/)
        //{
        //enemy.SetState(StateEnum.Attack); //강제로 줘도 됨.
        //}
    }

    public override void/*bool*/ OnStateExit()
    {        
        //애니메이션 구조상 꺼야한다면..
        enemy.Anim.Idle(false); //Idle 모션 그만~        

        //if (조건 만족여부)
        //{
        //    return true;
        //}
        //else
        //    return false;
    }
}
