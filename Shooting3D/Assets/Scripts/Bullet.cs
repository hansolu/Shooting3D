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

        //코루틴 콜 
        //혹은 인보크 사용
        Invoke("Die", 7f); //7초후에는 어쨌거나 애가 죽ㅁ음...
        Isalive = true;        
    }

    void FixedUpdate()
    {
        if (Isalive)
        {
            rigid.velocity = transform.forward * 10;
            //rigid.AddForce(transform.forward*Time.deltaTime * 10,ForceMode.Impulse);            

            //일정 시간후에 사라지도록.
        }
    }

    //IEnumerator
    void Die()
    {
        Isalive = false;
        //Destroy(this.gameObject);
        GameManager.Instance.ReturnBullet(this);
    }

    void OnTriggerEnter(Collider other)
    {
        //뭔가 판별해서 죽여야한다면 죽임..
        //총알에 맞아서 딜 줘야하는 객체들이라면 인터페이스 상속시키는 것도 좋을것.
        if (other.GetComponent<IHit>()!=null)
        {
            CancelInvoke();
            other.GetComponent<IHit>().Hit(damage);
            Die();
        }                
    }
}
