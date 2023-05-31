using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class FoodItem : Item 
//{ }
//public class Weapon : Item //활, 검 = 무슨검 무슨검... , 스태프...
//{
//    public CTEnum.WeaponKind weaponKind;
//    public Weapon(제이슨데이터 받아옴)
//    {
//        weaponKind = (CTEnum.WeaponKind)제이슨데이터.specificKind;
//    }
//}
public class Item  //얘도 후에 저장 및 아이템테이블에서의 정보 세팅 등을 생각하면 본래ItemData와 사용하는ItemData로 나눌것..
{    
    //아이템 데이터
    //public bool IsEmpty => Index == -1;
    public CTEnum.ItemKind itemKind = CTEnum.ItemKind.End;        
    public int Index { get; private set; } //고유 아이템인덱스
    public int MaxCount { get; private set; } = 0; //public 이므로 조심해야함. 소지할수 있는 최대 아이템 개수

    //슬롯에서의 기능
    public int Count { get; private set; } = 0; //public 이므로 조심해야함. 현재 내가 소지하고 있는 아이템 개수    
    

    public int AbleCount => MaxCount - Count;//얜 저장 필요없음. 기능

    public Item() //생성자. 빈 아이템 생성
    {
        Clear();
    }

    public Item(CTEnum.ItemKind itemkind, int index, int count, int maxcount) //뭔가 데이터 로드용
    {
        this.itemKind = itemkind;
        Count = count;
        Index = index;
        MaxCount = maxcount;
    }
           
    public void Clear()
    {
        itemKind = CTEnum.ItemKind.End;
        Count = 0;
        MaxCount = 0;
        Index = -1; //실제 내 아이템들 정보들은 1번부터 시작...
    }
    public void SetItem(Item item) //강제로 아이템 정보 바꿔줌.
    {
        itemKind = item.itemKind;
        Count = item.Count;
        Index = item.Index;
        MaxCount = item.MaxCount;
    }
    public void SetCount(int count) //강제로 개수 바꿈
    {        
        Count = count; 
    }

    public int AddCount(int addcount) //잘 더해졌으면 0 을 반환, 초과했다면 초과한 개수를 반환
    {
        Count += addcount;
        if (Count > MaxCount)
        {
            int returncount = MaxCount - Count;

            Count = MaxCount;
            //Debug.LogError($"최대 개수가 {MaxCount}개 인데 현재 개수가 {Count}개 임");
            return returncount;
        }
        else
            return 0;
    }
    public int SubCount(int subcount)
    {
        Count -= subcount;
        if (Count < 0)
        {
            int returncount = -Count;
            Count = 0;
            //Debug.LogError($"현재 개수가 {Count}개 임");
            return returncount;
        }
        else
        {            
            return 0;
        }
    }
}
