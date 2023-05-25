using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSample_PistolFire : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { //모션이 총을 완전히 들어올려서 쏠준비가 됐을때
        Debug.Log("OnStateEnter들어옴");
        GameManager.Instance.Player.SetIsGunReady(true);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Player.Instance.CreateBullet();
        //GameManager.Instance.Shoot(); //플레이어가 퍼블릭 접근이 불가할경우 게임매니저를 통해서 콜링        
        GameManager.Instance.Player.Shoot();//퍼블릭이라 바로 접근 가능.
    }     
}
