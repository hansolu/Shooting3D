using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class TestSingleton4 : SingletonMono<TestSingleton4>
{
    BaseScene scenescript; //�ش� �� ��ũ��Ʈ
    public Material mat;

    void Awake()
    {        
        if (_instance !=null /*�� ��ũ��Ʈ�� �̱����� �̹� �����ϰ�*/
            && _instance != this /*�� �̱��� �� ���� ������ ���� �ƴϸ�.  ==> ���� ���̾��Ű�� �����ؼ� �� ����� �Ǿ��ٸ�...*/)
        {
            Debug.Log("����� �ؽ��ڵ� " + base.GetHashCode());            
            Destroy(this.gameObject); //����Ƽ ���̾��Ű�� ���� //���߿� ���� ���� ~ �����.
            Destroy(this); //�̰ͱ��� ���� ���ص��Ǳ���.
        }
    }
    void Start()
    {
        mat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        Debug.Log("TestSingleton4 �ؽ��ڵ� : " + GetHashCode() +" / ��" +a);

        scenescript = FindObjectOfType<BaseScene>(); 
        //scenescript = GameObject.Find("ThisSceneScript").GetComponent<BaseScene>(); //���ٰ� ����

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
