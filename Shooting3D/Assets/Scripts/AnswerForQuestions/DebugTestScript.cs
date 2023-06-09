using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Input.anyKey //어떤키가 눌리고 있는지
        //Input.anyKeyDown //어떤 키든 눌렸는지

        Debug.Log("로그");
        Debug.LogWarning("로그 경고");
        Debug.LogError(" 확인하고 싶은 내용 ");  //디벨롭버전으로 빌드 + script debugging 체크 했을때 디버그로 볼수있음
    }
}
