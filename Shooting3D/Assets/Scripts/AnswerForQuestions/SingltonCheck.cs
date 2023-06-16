using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingltonCheck : Singleton.Singletonn<SingltonCheck>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("ddz");
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("자식싱글톤체크의 초기화");
    }
}
