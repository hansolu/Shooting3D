using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ResourceManager : SingletonMono<ResourceManager>
{
    public Sprite[] ItemSprites;
    //자잘한 프리팹
    public GameObject ItemPrefab;

    //아이템 테이블의 데이터들 을 가지고 있음...
    //ItemData[] Itemdatas; //제이슨 내지 로딩한 아이템 테이블의 정보들 가지구잇음...

    public Item CreateItem(CTEnum.ItemKind _kind)
    {
        //_index는 ItemKind에 속하는 인덱스 (랜덤으로 돌리도록 )
        int index = Random.Range(0, 5 /*_kind의 마지막 번호*/);
        return new Item(_kind, index, 1, 5);
    }

    public Item CreateItem(int _index)
    {
        //_index의 kind 가져올것
        return new Item(CTEnum.ItemKind.End /*아이템 정보 가져오기 해서 아이템 카인드 맞춰서 넣어줘야겠죠.*/, _index, 1, 5);
    }

}

//변하지않을 아이템 정보들..
public class ItemData
{
    public CTEnum.ItemKind itemKind = CTEnum.ItemKind.End;
    public int Index { get; private set; } //고유 아이템인덱스
    public int MaxCount { get; private set; } = 0; //public 이므로 조심해야함. 소지할수 있는 최대 아이템 개수
}
