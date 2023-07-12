using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour
{
    public Camera cam;
    Coroutine rotcor = null;
    Coroutine movecor = null;
    RaycastHit hit;

    Vector3 clickPos = Vector3.zero;
    Quaternion dir = Quaternion.identity;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                clickPos = hit.point;
                dir = Quaternion.LookRotation((clickPos - transform.position).normalized);
                dir.x = 0;
                dir.z = 0;
                if (rotcor != null)
                {
                    StopCoroutine(rotcor);
                    rotcor = null;
                }
                rotcor = StartCoroutine(Rotate());

                 if (movecor != null)
                {
                    StopCoroutine(movecor);
                    movecor = null;
                }
                movecor = StartCoroutine(Move());
            }                                                            
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (Mathf.Abs( (transform.position - clickPos).sqrMagnitude) <= 5f)
            {
                yield break;
            }
            transform.position = Vector3.Lerp(transform.position ,clickPos, 
                Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator Rotate()
    {
        while (true)
        {                        
            transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime*10);          
            if(Mathf.Abs( transform.rotation.eulerAngles.y - dir.eulerAngles.y) < 10)
            {
                Debug.Log("³¡");
                yield break;
            }
            yield return null;
        }
    }
}
