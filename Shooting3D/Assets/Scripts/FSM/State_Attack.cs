using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    public State_Attack(Enemy _enemy) : base(_enemy)
    {
        //enemy = _enemy;
    }

    public override void OnStateEnter()
    {
        //애니메이션 시작해야한다면 시작시킴..
    }
    public override void OnStateStay()
    {
        //이상태일동안 해야하는 무언가...

        //공격 거리안에 있는지 뭐하는지~ 이 공격의 패턴 뭔가 구현하고 싶은것 구현
    }
    public override void OnStateExit()
    {
        //공격이 끝났을때 이펙트 수거해야한다면 수거하고
        //애니메이션 조건 끝내야한다면 끝내주고...
    }    
}
