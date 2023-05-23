using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float x, y = 0;
    Vector3 orgPos = Vector3.zero;
    Vector3 vec = Vector3.zero;
    Vector3 rotationVec = Vector3.zero;
    Vector3 currentVel = Vector3.zero;
    public Transform target;
    Camera cam;
    void Start()
    {
        orgPos = transform.position;
        cam = this.GetComponent<Camera>();
    }

    void Update()
    {
        //���� �ܾƿ�..
        Vector2 scroll = Input.mouseScrollDelta;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll.y, 15, 40);

        //���콺 �������� �޾� ī�޶� ȸ��.
        y += Input.GetAxisRaw("Mouse X");
        x -= Input.GetAxisRaw("Mouse Y");

        vec.x = Mathf.Clamp(x, -20, 60); //
        vec.y = y;

        rotationVec = Vector3.SmoothDamp(rotationVec, vec, ref currentVel, Time.deltaTime); //�ε巯�� ȸ��.
        transform.eulerAngles = rotationVec; //���� �� ȸ���� ����

        transform.position = target.position + orgPos; //Ÿ���� �����Ÿ��� ��ġ�� ���󰡰� ��
    }
}
