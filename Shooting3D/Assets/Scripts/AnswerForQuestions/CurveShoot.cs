using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveShoot : MonoBehaviour
{
    bool IsShoot = false; 
    float power = 0;

    public Transform effectTr; //����Ʈ ��ġ �����ϱ� ����
    public Transform ShootTr;  //�߻�Ǵ� ��ü

    float gravity = 9.8f;
    Vector3 orgpos = Vector3.zero;
    Vector3 dest = Vector3.zero; //�ӽú���. �� ���� ��� ������ �ӽú���
    Vector3 endPos = Vector3.zero; //�̸� ����ϴ� ��������
    float Timer = 0; //Ÿ�̸� �ӽú���
    float speed,anglerad, initialSpeedX, initialSpeedY=0; //�ӽú���....
    void Start()
    {        
        speed = 5; //������ �ӷ�
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            effectTr.gameObject.SetActive(false);
            power = 1;
        }
        else if (Input.GetKey(KeyCode.Space))
        {            
            power += Time.deltaTime;
            Debug.Log("power : " + power);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (power >= 10)
            {
                power = 10;
            }                        

            anglerad = (40 + power) * Mathf.Deg2Rad; //�߻� ����...
            dest = Vector3.zero;
            orgpos = ShootTr.position; //�̵��� ���� ��ġ


            //������ �⺻ ���� ����
            initialSpeedX = power * Mathf.Cos(anglerad) * speed; 
            initialSpeedY = power * Mathf.Sin(anglerad) * speed;


            //���� �ð� ���
            float landingTime = (initialSpeedY + Mathf.Sqrt(initialSpeedY * initialSpeedY + 2f * gravity * transform.position.y)) / gravity;

            // �������� ���
            effectTr.gameObject.SetActive(true);
            effectTr.position = orgpos + ShootTr.forward * initialSpeedX * landingTime; //�̵��� ��ü�� ���� ��ġ + ��ü�� �ٶ󺸰��ִ� ���� * �������� ���(x���ϴ� �� * �����ð�)
            Debug.Log("����Ʈ ��ġ " +effectTr.position);
            Timer = 0;
            IsShoot = true;
        }

        if (IsShoot)
        {            
            Timer += Time.deltaTime;                                   

            dest = Vector3.zero;            
            
            dest.y = initialSpeedY * Timer - (0.5f * gravity * Timer * Timer); //������������ y�� ���ϴ� ��
            dest += ShootTr.forward * initialSpeedX* Timer; //�̵��� ��ü�� �ٶ󺸴� ���� * ������������ x�� ( x����~ * �ش� �ð�)
                        
            ShootTr.position = orgpos + dest; //������ġ + dest�� �� ������ ���Ž�����.
            
            if (dest.y <= orgpos.y) //�����ִ� ���̰����� ���ƿ���.
            {
                Debug.Log("������ :" +dest);               
                IsShoot = false;
            }
        }
    }
}
