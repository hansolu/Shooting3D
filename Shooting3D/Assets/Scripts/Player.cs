using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform GunObjTr; //�ѱ��� Ʈ������
    public Transform Holster; //�ѱ� �տ� ����������� ��ġ
    public Transform Gun_HandTr; //�ѱ� �տ� ����ֱ� ���� ��ġ.

    Gun gun; //���� ���� ���� �Ѿ� ������ ��ġ �޾ƿ��� ����.

    Animator anim;        
    float x, z = 0;   
    [SerializeField]
    float originSpeed = 4;
    float speed = 0;

    bool IsShoot = false; //����
    bool IsAbleShoot = true; //�� ��Ⱑ ���������� true�� ��.
    float shootDelayTime = 1f; //�� ��� ����
    float shootTimer = 0; //�ѽ�� ���� üũ���� ����
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
        IsAbleShoot = true; //���۽ÿ� ������ ��� ���ɻ��¿����ϰ�
        IsShoot = false;  //������ ���� ���� ����.
    }
    
    void Update()
    {              
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");        
        pos.x = x;
        pos.z = z;                
        pos.Normalize(); //�밢�� �̶�� ���� �������� ������ ���� �� ����.        

        if (x == 0 && z == 0)
        {
            anim.SetBool("IsRun", false);
        }
        else //���� ���� ����.
        {
            anim.SetBool("IsRun", true);

            #region Ű���带 ������ ȸ�� ��Ŵ
            //if (x < 0) //������ ��������
            //{
            //    transform.Rotate(Vector3.up, -0.4f); //�������� ȸ��
            //}
            //else if (x > 0) //������ ��������
            //{
            //    transform.Rotate(Vector3.up, 0.4f); //������ ���� ȸ��
            //}
            //else
            //{
            //    if (z < 0) //�Ʒ�Ű�� ������ ����
            //    {
            //        if (transform.rotation.y !=0 && transform.rotation.y != 180)//�������� �ƴ� ���¶��
            //        {
            //            transform.rotation = Quaternion.Lerp/*Unclamped*/(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime); 
            //            //180�� . ��������� ���Ͽ� �ε巴�� ȸ����Ŵ
            //        }                    
            //    }
            //    else if(z > 0)
            //    {
            //        transform.rotation = Quaternion.Lerp/*Unclamped*/(transform.rotation, Quaternion.identity, Time.deltaTime);
            //        //0,0,0 ����(����)�� ������ �ε巴�� ȸ����Ŵ.
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

        if (IsAbleShoot == false)//Ÿ�̸� �ʿ�..
        {
            //#########
        }
        

        if (Input.GetMouseButtonDown(0)) //������ ����
        {
            if (IsAbleShoot == false) //������� ���¸� ���ư���.
            {
                return;
            }                        
            anim.SetBool("IsShoot", true);
            GunObjTr.SetParent(Gun_HandTr); //�� ����ġ�� �޾Ƶ�
            GunObjTr.localPosition = Vector3.zero; //���� �θ�� ��ġ ������.
            GunObjTr.localRotation = Quaternion.identity;
        }
        else if (Input.GetMouseButton(0)) //�����ð����� ��� ����
        {            
            //�����ð� ���� �����ؼ� ���� ���� => �Ѿ� ����...
            //gun.BulletPointTr ;
        }
        else if (Input.GetMouseButtonUp(0)) //���� ���� ����
        {            
            anim.SetBool("IsShoot", false);            
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PistolHolster") &&
    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            GunObjTr.SetParent(Holster); //�� ���ڸ���
            GunObjTr.localPosition = Vector3.zero; //���� �θ�� ��ġ ������.
            GunObjTr.localRotation = Quaternion.identity;
        }

        //transform.position += pos * Time.deltaTime * speed;
        transform.Translate(pos * Time.deltaTime * speed, Space.World);


        //ī�޶� ���� �ܾƿ�..
        scroll = Input.mouseScrollDelta;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll.y, 10, 100); //��ũ���� ������ ī�޶� �־���.

        //���콺��ġ���� ȭ������ ���̸� ����, �ش� ���̰� ��򰡿� �¾�����  => ���߷��� �ּ��� �ٴ��̶� �־��... 
        ray = cam.ScreenPointToRay(Input.mousePosition);

        //ref  �ݵ�� �Ѱ��ֱ� ���� �����س������. //out�� �����ϸ鼭 �����ޱ� ����.
        //RaycastHit hit;
        if (Physics.Raycast(ray, out /*RaycastHit*/hit)) //���� ������ �ִٸ�
        {
            vec.x = hit.point.x;
            vec.y = transform.position.y;
            vec.z = hit.point.z;
            transform.forward = vec;
        }
    }

}
