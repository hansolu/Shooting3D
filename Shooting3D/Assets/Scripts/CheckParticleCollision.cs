using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParticleCollision : MonoBehaviour
{
    //��ü ��ũ��Ʈ ����
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("���� ���ͷ��� �־���ϴ� ����Ʈ �ϰ��"))
        {
            //��ü��ũ��Ʈ ������ ���� �Լ� �ߵ�
        }
    }

    //�浹�� ����Ʈ ���̰� �� ���.
    //void OnCollisionEnter(Collision collision)
    //{
    //    ContactPoint cp = collision.GetContact(0);
    //    //cp.point //�浹�� �� �� �� ����        
    //    //cp.normal //�浹�� ���� ����
    //    Quaternion rotation =  Quaternion.LookRotation(-cp.normal); //
    //    GameObject effect = Instantiate(����Ʈ������, cp.point, rotation);
        
    //    //���� �� ��ü�� �浹�ؼ� ������ ����Ʈ�� ���������� ��� �ϵ��� ���� ������.
    //}
}
