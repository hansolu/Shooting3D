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
        //�ִϸ��̼� �����ؾ��Ѵٸ� ���۽�Ŵ..
    }
    public override void OnStateStay()
    {
        //�̻����ϵ��� �ؾ��ϴ� ����...

        //���� �Ÿ��ȿ� �ִ��� ���ϴ���~ �� ������ ���� ���� �����ϰ� ������ ����
    }
    public override void OnStateExit()
    {
        //������ �������� ����Ʈ �����ؾ��Ѵٸ� �����ϰ�
        //�ִϸ��̼� ���� �������Ѵٸ� �����ְ�...
    }    
}
