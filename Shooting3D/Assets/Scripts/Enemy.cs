using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHit
{
    public void Hit(float damage)
    {
        Debug.Log("Hit 불림. 데미지 : "+damage);
    }
}
