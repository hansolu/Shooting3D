using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class SavePosition : MonoBehaviour
{
    //아이템 정보 원본을 어디 가지고 있다는 전제하에 => 그 아이템 정보는 index로 접근가능.

    //인벤토리 => 슬롯 번호, 아이템 정보(인덱스), 아이템 소유개수 / 그외 가변적인 정보들...

    //Path.Combine(Application.dataPath, "dataPath.txt"); //빌드한 폴더안의 Data폴더 안.... => 여기에 저장하는것이 가장 적합        


    //뉴튼 제이슨 설치 = 유니티 패키지 매니저에서 왼쪽 상단 플러스(더하기 표시 ) 클릭하여 add package by name선택 => com.unity.nuget.newtonsoft-json   입력하여 설치
    //설치 완료후 using Newtonsoft.Json; 해주면 사용가능.

    void Start()
    {
        AAA aa = new AAA();
        aa.datas = new List<SlotData>() { new SlotData(1,1), new SlotData(2, 2) };
        string str = JsonConvert.SerializeObject(aa /*저장할 클래스~*/, Formatting.Indented);
        Debug.Log(str);
    }
}

public class AAA
{
    public List<SlotData> datas = new List<SlotData>();
}
public class SlotData
{
    public int Index; //슬롯 번호 //만약 리스트가 반드시 순서대로 있다면. ㄱ중간에 빈 슬롯이 없다면야 굳이 없어도 되겟지만...
    public int ItemIndex;//아이템 인덱스번호
    public int ItemCount; //이 슬롯에 들어있는 아이템 개수
    public SlotData(int index, int count)
    {
        Index = index;
        ItemCount = count;
    }
}
