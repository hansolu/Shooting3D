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

        //�ڷ�ƾ �� 
        //Ȥ�� �κ�ũ ���
        Invoke("Die", 7f); //7���Ŀ��� ��·�ų� �ְ� �פ���...
        Isalive = true;        
    }

    void FixedUpdate()
    {
        if (Isalive)
        {
            rigid.velocity = transform.forward * 10;
            //rigid.AddForce(transform.forward*Time.deltaTime * 10,ForceMode.Impulse);            

            //���� �ð��Ŀ� ���������.
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
        //���� �Ǻ��ؼ� �׿����Ѵٸ� ����..
        //�Ѿ˿� �¾Ƽ� �� ����ϴ� ��ü���̶�� �������̽� ��ӽ�Ű�� �͵� ������.
        if (other.GetComponent<IHit>()!=null)
        {
            CancelInvoke();
            other.GetComponent<IHit>().Hit(damage);
            Die();
        }                
    }
}
