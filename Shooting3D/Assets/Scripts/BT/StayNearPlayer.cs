using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayNearPlayer : Node
{
    //private Animator anim;

    public StayNearPlayer(Transform transform)
    {
        //anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("StayNearPlayer 의 노드임");
        //anim.SetBool("Following", false);

        Debug.Log("Idle상태 : 기다리는 애니메이션 진행중");

        return state = NodeState.Running;
    }
}
