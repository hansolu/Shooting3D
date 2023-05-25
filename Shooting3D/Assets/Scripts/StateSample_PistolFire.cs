using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSample_PistolFire : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { //����� ���� ������ ���÷��� ���غ� ������
        Debug.Log("OnStateEnter����");
        GameManager.Instance.Player.SetIsGunReady(true);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Player.Instance.CreateBullet();
        //GameManager.Instance.Shoot(); //�÷��̾ �ۺ� ������ �Ұ��Ұ�� ���ӸŴ����� ���ؼ� �ݸ�        
        GameManager.Instance.Player.Shoot();//�ۺ��̶� �ٷ� ���� ����.
    }     
}
