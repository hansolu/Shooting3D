using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerIsNear : Node
{
    private static int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    private Transform transform; //transform == pet의 Transform과 동일함.
    //private Animator anim;

    public CheckPlayerIsNear(Transform transform) //
    {
        this.transform = transform;
        //anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("CheckPlayerIsNear 의 노드임");


        var collider = Physics.OverlapSphere(transform.position, 5.0f, 
            playerLayerMask);

        if (collider.Length <= 0) //거리안에 사람이 없음.
            return state = NodeState.Failure;

        //anim.SetBool("Following", false);
        Debug.Log("IDLE 상태 : 따라가기를 멈추는 애니메이션");
        return state = NodeState.Success;
    }
}
