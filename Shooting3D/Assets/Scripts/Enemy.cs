using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHit
{
    StateMachine stateMachine; //������ '����'�� ���� ����.
    AnimationComponent anim;
    public AnimationComponent Anim => anim;
    public StateEnum nowState;
    public StateEnum ex_State; //�ʿ��ϴٸ� ���� ������ ����.

    void Awake()
    {
        nowState = StateEnum.Idle;
        ex_State = StateEnum.None;
        stateMachine = new StateMachine(this
            /*,�ش� Enemy�� ���� State ��Ī�ؼ� ������. */);        
    }

    public void Hit(float damage)
    {
        Debug.Log("Hit �Ҹ�. ������ : "+damage);
    }
}
