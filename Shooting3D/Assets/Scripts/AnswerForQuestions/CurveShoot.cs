using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveShoot : MonoBehaviour
{
    bool IsShoot = false; 
    float power = 0;

    public Transform effectTr; //이펙트 위치 수정하기 위함
    public Transform ShootTr;  //발사되는 주체

    float gravity = 9.8f;
    Vector3 orgpos = Vector3.zero;
    Vector3 dest = Vector3.zero; //임시변수. 내 공을 계속 움직일 임시변수
    Vector3 endPos = Vector3.zero; //미리 계산하는 도착지점
    float Timer = 0; //타이머 임시변수
    float speed,anglerad, initialSpeedX, initialSpeedY=0; //임시변수....
    void Start()
    {        
        speed = 5; //임의의 속력
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

            anglerad = (40 + power) * Mathf.Deg2Rad; //발사 각도...
            dest = Vector3.zero;
            orgpos = ShootTr.position; //이동전 원래 위치


            //포물선 기본 시작 각도
            initialSpeedX = power * Mathf.Cos(anglerad) * speed; 
            initialSpeedY = power * Mathf.Sin(anglerad) * speed;


            //도착 시간 계산
            float landingTime = (initialSpeedY + Mathf.Sqrt(initialSpeedY * initialSpeedY + 2f * gravity * transform.position.y)) / gravity;

            // 도착지점 출력
            effectTr.gameObject.SetActive(true);
            effectTr.position = orgpos + ShootTr.forward * initialSpeedX * landingTime; //이동할 주체의 원래 위치 + 주체가 바라보고있는 방향 * 도착지점 계산(x구하는 식 * 도착시간)
            Debug.Log("이펙트 위치 " +effectTr.position);
            Timer = 0;
            IsShoot = true;
        }

        if (IsShoot)
        {            
            Timer += Time.deltaTime;                                   

            dest = Vector3.zero;            
            
            dest.y = initialSpeedY * Timer - (0.5f * gravity * Timer * Timer); //포물선에서의 y값 구하는 식
            dest += ShootTr.forward * initialSpeedX* Timer; //이동할 주체가 바라보는 방향 * 포물선에서의 x값 ( x각도~ * 해당 시간)
                        
            ShootTr.position = orgpos + dest; //원래위치 + dest로 매 프레임 갱신시켜줌.
            
            if (dest.y <= orgpos.y) //원래있던 높이값으로 돌아왔음.
            {
                Debug.Log("도착지 :" +dest);               
                IsShoot = false;
            }
        }
    }
}
