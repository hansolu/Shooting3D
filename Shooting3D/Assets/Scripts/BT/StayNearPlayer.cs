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
        Debug.Log("StayNearPlayer �� �����");
        //anim.SetBool("Following", false);

        Debug.Log("Idle���� : ��ٸ��� �ִϸ��̼� ������");

        return state = NodeState.Running;
    }
}
