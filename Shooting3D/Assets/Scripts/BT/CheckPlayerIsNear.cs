using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerIsNear : Node
{
    private static int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    private Transform transform; //transform == pet�� Transform�� ������.
    //private Animator anim;

    public CheckPlayerIsNear(Transform transform) //
    {
        this.transform = transform;
        //anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("CheckPlayerIsNear �� �����");


        var collider = Physics.OverlapSphere(transform.position, 5.0f, 
            playerLayerMask);

        if (collider.Length <= 0) //�Ÿ��ȿ� ����� ����.
            return state = NodeState.Failure;

        //anim.SetBool("Following", false);
        Debug.Log("IDLE ���� : ���󰡱⸦ ���ߴ� �ִϸ��̼�");
        return state = NodeState.Success;
    }
}
