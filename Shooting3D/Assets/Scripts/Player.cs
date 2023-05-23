using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform GunObjTr; //총기의 트랜스폼
    public Transform Holster; //총기 손에 안쥐었을때의 위치
    public Transform Gun_HandTr; //총기 손에 쥐어주기 위한 위치.

    Gun gun; //내가 가진 총의 총알 생성할 위치 받아오기 위함.

    Animator anim;        
    float x, z = 0;   
    [SerializeField]
    float originSpeed = 4;
    float speed = 0;

    bool IsShoot = false; //쐈음
    bool IsAbleShoot = true; //총 쏘기가 가능해질때 true가 됨.
    float shootDelayTime = 1f; //총 쏘는 간격
    float shootTimer = 0; //총쏘는 간격 체크위한 변수
    Vector3 pos = Vector3.zero;
    Vector3 vec = Vector3.zero;
    Vector2 scroll = Vector2.zero;
    public Camera cam;
    Ray ray;
    RaycastHit hit;        
    
    void Start()
    {
        anim = GetComponent<Animator>();
        gun = GunObjTr.GetComponent<Gun>();
        speed = originSpeed;
        IsAbleShoot = true; //시작시에 언제든 쏘기 가능상태여야하고
        IsShoot = false;  //쏘지는 않은 상태 세팅.
    }
    
    void Update()
    {              
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");        
        pos.x = x;
        pos.z = z;                
        pos.Normalize(); //대각선 이라고 좀더 빨라지는 현상을 없앨 수 있음.        

        if (x == 0 && z == 0)
        {
            anim.SetBool("IsRun", false);
        }
        else //뭐라도 누른 상태.
        {
            anim.SetBool("IsRun", true);

            #region 키보드를 눌러서 회전 시킴
            //if (x < 0) //왼쪽을 눌렀을때
            //{
            //    transform.Rotate(Vector3.up, -0.4f); //왼쪽으로 회전
            //}
            //else if (x > 0) //오른쪽 눌렀을때
            //{
            //    transform.Rotate(Vector3.up, 0.4f); //오른쪽 으로 회전
            //}
            //else
            //{
            //    if (z < 0) //아래키를 누르고 있음
            //    {
            //        if (transform.rotation.y !=0 && transform.rotation.y != 180)//정방향이 아닌 상태라면
            //        {
            //            transform.rotation = Quaternion.Lerp/*Unclamped*/(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime); 
            //            //180도 . 모니터쪽을 향하여 부드럽게 회전시킴
            //        }                    
            //    }
            //    else if(z > 0)
            //    {
            //        transform.rotation = Quaternion.Lerp/*Unclamped*/(transform.rotation, Quaternion.identity, Time.deltaTime);
            //        //0,0,0 방향(위쪽)을 보도록 부드럽게 회전시킴.
            //    }                
            //}
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("IsWalk", true);
            speed = originSpeed * 0.5f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("IsWalk", false);
            speed = originSpeed;
        }

        if (IsAbleShoot == false)//타이머 필요..
        {
            //#########
        }
        

        if (Input.GetMouseButtonDown(0)) //공격의 시작
        {
            if (IsAbleShoot == false) //쏠수없는 상태면 돌아가기.
            {
                return;
            }                        
            anim.SetBool("IsShoot", true);
            GunObjTr.SetParent(Gun_HandTr); //총 손위치로 달아둠
            GunObjTr.localPosition = Vector3.zero; //나의 부모와 일치 시켜줌.
            GunObjTr.localRotation = Quaternion.identity;
        }
        else if (Input.GetMouseButton(0)) //일정시간마다 쏘는 행위
        {            
            //일정시간 조건 만족해서 공격 가능 => 총알 생성...
            //gun.BulletPointTr ;
        }
        else if (Input.GetMouseButtonUp(0)) //공격 상태 해제
        {            
            anim.SetBool("IsShoot", false);            
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PistolHolster") &&
    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            GunObjTr.SetParent(Holster); //총 제자리로
            GunObjTr.localPosition = Vector3.zero; //나의 부모와 일치 시켜줌.
            GunObjTr.localRotation = Quaternion.identity;
        }

        //transform.position += pos * Time.deltaTime * speed;
        transform.Translate(pos * Time.deltaTime * speed, Space.World);


        //카메라 줌인 줌아웃..
        scroll = Input.mouseScrollDelta;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll.y, 10, 100); //스크롤을 내리면 카메라가 멀어짐.

        //마우스위치에서 화면으로 레이를 쏴서, 해당 레이가 어딘가에 맞았을때  => 맞추려면 최소한 바닥이라도 있어야... 
        ray = cam.ScreenPointToRay(Input.mousePosition);

        //ref  반드시 넘겨주기 전에 선언해놨어야함. //out은 선언하면서 돌려받기 가능.
        //RaycastHit hit;
        if (Physics.Raycast(ray, out /*RaycastHit*/hit)) //뭔가 맞은게 있다면
        {
            vec.x = hit.point.x;
            vec.y = transform.position.y;
            vec.z = hit.point.z;
            transform.forward = vec;
        }
    }

}
