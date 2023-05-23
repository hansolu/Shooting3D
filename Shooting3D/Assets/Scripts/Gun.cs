using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletPoint;
    public Vector3 BulletPointTr => BulletPoint.transform.position; //GetBulletPoint()함수와 동일한 기능
    public Vector3 GetBulletPoint() //BulletPointTr 와 동일하지만 함수로 부름..
    {
        return BulletPoint.transform.position; //로컬 아니고 월드 좌표로 줌
    }
}
