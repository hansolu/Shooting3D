using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHit
{
    StateMachine stateMachine; //정말로 '상태'에 대한 모든것.
    AnimationComponent anim;
    public AnimationComponent Anim => anim;
    public StateEnum nowState;
    public StateEnum ex_State; //필요하다면 이전 정보도 저장.

    void Awake()
    {
        nowState = StateEnum.Idle;
        ex_State = StateEnum.None;
        stateMachine = new StateMachine(this
            /*,해당 Enemy가 가질 State 매칭해서 셋해줌. */);        
    }

    public void Hit(float damage)
    {
        Debug.Log("Hit 불림. 데미지 : "+damage);
    }
}
