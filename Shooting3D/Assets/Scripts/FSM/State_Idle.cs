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
        enemy.Anim.Idle(true); //Idle ��� �����ض�
    }
    

    public override void OnStateStay()
    {
        //�����ð����� �ɾ�ٴϰ� �ϰ�ʹ��� ���� �ϰ������...
        //��ɱ���...

        //����Ǻ��ϰ����..
        //�����ġ Ȥ�� ����� ���̾�...��������        
        //�÷��̾� .. ����.. 
        //enemy.transform.position //Enemy������ ���� ����.
        //if (�÷��̾� ���� /*�÷��̾ �Ŵ����� ����־ �Ŵ����� �����ϰų�
        // �÷��̾� ���� ����� Enemy��ũ��Ʈ �ȿ��� �־�θ� ��*/)
        //{
        //enemy.SetState(StateEnum.Attack); //������ �൵ ��.
        //}
    }

    public override void/*bool*/ OnStateExit()
    {        
        //�ִϸ��̼� ������ �����Ѵٸ�..
        enemy.Anim.Idle(false); //Idle ��� �׸�~        

        //if (���� ��������)
        //{
        //    return true;
        //}
        //else
        //    return false;
    }
}
