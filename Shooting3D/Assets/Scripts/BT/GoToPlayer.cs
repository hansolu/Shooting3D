using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : Node
{
    private Transform player;
    private Transform transform;
    //private Animator anim;

    public GoToPlayer(Transform player, Transform transform)
    {
        this.player = player;
        this.transform = transform;
        //anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Debug.Log("GoToPlayer 의 노드임");
        transform.LookAt(player); 
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime);
        //anim.SetBool("Following", true);
        Debug.Log("따라가고있는중");

        return state = NodeState.Running;
    }
}
