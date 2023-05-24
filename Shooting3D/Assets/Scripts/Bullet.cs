using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigid;
    float damage = 5;    
    bool Isalive = false;
    public void SetInit(Transform _tr)
    {
        if (rigid ==null)
        {
            rigid = GetComponent<Rigidbody>();
        }
        Isalive = false;
        transform.SetParent(_tr);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.SetParent(null);
        Isalive = true;
    }

    void FixedUpdate()
    {
        if (Isalive)
        {
            rigid.AddForce(transform.forward*Time.deltaTime * 5,ForceMode.Impulse);
            Debug.Log(transform.forward);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHit>()!=null)
        {
            other.GetComponent<IHit>().Hit(damage);
        }

        Isalive = false;
        Destroy(this);
        //this.gameObject.SetActive(false); //오브젝4트 풀이잇다면 원래 풀에 넣어줘야할것.. 
        //뭔가 판별해서 죽여야한다면 죽임..
        //총알에 맞아서 딜 줘야하는 객체들이라면 인터페이스 상속시키는 것도 좋을것.
    }
}
