using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletPoint;
    public Vector3 BulletPointTr => BulletPoint.transform.position; //GetBulletPoint()�Լ��� ������ ���
    public Vector3 GetBulletPoint() //BulletPointTr �� ���������� �Լ��� �θ�..
    {
        return BulletPoint.transform.position; //���� �ƴϰ� ���� ��ǥ�� ��
    }
}
