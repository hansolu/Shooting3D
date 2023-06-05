using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParticleCollision : MonoBehaviour
{
    //본체 스크립트 ㅁㅁ
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("나와 인터렉션 있어야하는 이펙트 일경우"))
        {
            //본체스크립트 ㅁㅁ의 ㅁㅁ 함수 발동
        }
    }

    //충돌한 이펙트 보이게 잘 출력.
    //void OnCollisionEnter(Collision collision)
    //{
    //    ContactPoint cp = collision.GetContact(0);
    //    //cp.point //충돌한 그 딱 그 지점        
    //    //cp.normal //충돌한 법선 벡터
    //    Quaternion rotation =  Quaternion.LookRotation(-cp.normal); //
    //    GameObject effect = Instantiate(이펙트프리팹, cp.point, rotation);
        
    //    //뭔가 두 물체가 충돌해서 생성된 이펙트를 정상적으로 출력 하도록 생성 가능함.
    //}
}
