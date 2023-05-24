using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSample : StateMachineBehaviour
{
    //public Player player;

    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("OnStateEnterµé¾î¿È");
        
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Destroy(clone);
    //}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("On Attack Update ");
        Player.Instance.CreateBullet();
    }

    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("On Attack Move ");
    //}

    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("On Attack IK ");
    //}
}
