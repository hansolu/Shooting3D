using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTest : MonoBehaviour
{
    LineRenderer linerender;
    Camera cam;
    Vector2 mouseStartPos = Vector2.zero;
    Vector2 mouseEndPos = Vector2.zero;
    Vector2 mouseRightPos = Vector2.zero;
    Vector2 mouseLeftPos = Vector2.zero;    

    Vector3 startpos = Vector3.zero;
    Vector3 endpos = Vector3.zero;

    Vector3 rightup = Vector3.zero;
    Vector3 leftdown = Vector3.zero;

    Vector3 centerPos = Vector3.zero;
    Vector3 size = Vector3.zero;

    Ray ray;
    RaycastHit hit;

    public GameObject[] AllCollider;

    void Awake()
    {
        cam = GetComponent<Camera>();
        linerender = GetComponent<LineRenderer>();
        size.z = Mathf.Abs(cam.transform.position.z * 2);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("시작지점 클릭위치 " + Input.mousePosition);
            ray = cam.ScreenPointToRay(Input.mousePosition);

            mouseStartPos = Input.mousePosition;

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                startpos = hit.point;
                Debug.Log("startpos : "+ startpos);
            }
            
        }
        else if (Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            mouseEndPos = Input.mousePosition;

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                endpos = hit.point;
            }


            mouseRightPos.y = mouseStartPos.y;
            mouseRightPos.x = mouseEndPos.x;
            mouseLeftPos.y = mouseEndPos.y;
            mouseLeftPos.x = mouseStartPos.x;

            ray = cam.ScreenPointToRay(mouseRightPos);

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                rightup = hit.point;
            }

            ray = cam.ScreenPointToRay(mouseLeftPos);

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                leftdown = hit.point;
            }
            //rightup.z = startpos.z;
            //rightup.x = endpos.x;
            //leftdown.z = endpos.z;
            //leftdown.x = startpos.x;


            linerender.SetPosition(0, startpos);
            linerender.SetPosition(1, rightup);
            linerender.SetPosition(2, endpos);
            linerender.SetPosition(3, leftdown);
            linerender.SetPosition(4, startpos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ray = cam.ScreenPointToRay((mouseStartPos + mouseEndPos) * 0.5f);

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                centerPos = hit.point;
            }
             
            //centerPos.x=(startpos.x + endpos.x) * 0.5f;
            //centerPos.z = (startpos.z + endpos.z) * 0.5f;
            size.x = Mathf.Abs(startpos.x - endpos.x)* 0.5f;            
            size.y = Mathf.Abs(startpos.z - endpos.z) * 0.5f;                        
            Collider[] cols = Physics.OverlapBox(centerPos,size, cam.transform.rotation, 1 << LayerMask.NameToLayer("Slot"));
            Debug.Log("centerPos : " + centerPos + "/ size : " + size);
            Debug.Log("endpos : " + endpos);

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i].gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            for (int i = 0; i < AllCollider.Length; i++)
            {
                AllCollider[i].SetActive(true);
            }
        }
    }        
}
