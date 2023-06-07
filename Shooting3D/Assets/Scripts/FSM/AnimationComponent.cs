using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Idle(bool _on)
    {
        _anim.SetBool("Idle", _on);
    }
    public void Attack()
    {        
        _anim.SetTrigger("Attack");
    }
}
