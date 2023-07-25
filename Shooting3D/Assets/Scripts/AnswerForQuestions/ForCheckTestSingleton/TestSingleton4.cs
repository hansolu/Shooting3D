using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton4 : SingletonMono<TestSingleton4>
{
    BaseScene scenescript; //해당 씬 스크립트
    public Material mat;

    void Awake()
    {        
        if (_instance !=null /*이 스크립트의 싱글톤이 이미 존재하고*/
            && _instance != this /*그 싱글톤 의 변수 내용이 내가 아니면.  ==> 내가 하이어라키상에 존재해서 또 생기게 되었다면...*/)
        {
            Debug.Log("사라질 해시코드 " + base.GetHashCode());            
            Destroy(this.gameObject); //유니티 하이어라키를 지움 //나중에 생긴 나를 ~ 지운다.
            Destroy(this); //이것까진 굳이 안해도되긴함.
        }
    }
    void Start()
    {
        mat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        Debug.Log("TestSingleton4 해시코드 : " + GetHashCode() +" / 값" +a);

        scenescript = FindObjectOfType<BaseScene>(); 
        //scenescript = GameObject.Find("ThisSceneScript").GetComponent<BaseScene>(); //윗줄과 동일

        scenescript.CommonFunc();


        if (scenescript.SceneName == SceneName.Scene1)
        {
            (scenescript as Scene1).AAAA();
            (scenescript as Scene1).OnlyThisSceneObjects[0].SetActive(false);
            (scenescript as Scene1).OnlyThisSceneObjects[1].SetActive(true);
        }
    }
    public  int a = 0;
    public override int GetHashCode()
    {
        a++;
        SetMatColor();
        return base.GetHashCode();
    }

    public void SetMatColor()
    {
        if (a <= 2)
        {
            mat.color = Color.green;
        }
        else if(a <= 4)
        {
            mat.color = Color.blue;
        }
        else 
        {
            mat.color = Color.red;
        }
    }
}
