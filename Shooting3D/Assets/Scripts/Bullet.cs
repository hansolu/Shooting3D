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
        //this.gameObject.SetActive(false); //������4Ʈ Ǯ���մٸ� ���� Ǯ�� �־�����Ұ�.. 
        //���� �Ǻ��ؼ� �׿����Ѵٸ� ����..
        //�Ѿ˿� �¾Ƽ� �� ����ϴ� ��ü���̶�� �������̽� ��ӽ�Ű�� �͵� ������.
    }
}
