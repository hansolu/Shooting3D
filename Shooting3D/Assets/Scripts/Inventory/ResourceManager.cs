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

    public Item CreateItem(CTEnum.ItemKind _kind, int _index)
    {
        return new Item(_kind, _index, 1, 5);
    }
}

//변하지않을 아이템 정보들..
public class ItemData
{
    public CTEnum.ItemKind itemKind = CTEnum.ItemKind.End;
    public int Index { get; private set; } //고유 아이템인덱스
    public int MaxCount { get; private set; } = 0; //public 이므로 조심해야함. 소지할수 있는 최대 아이템 개수
}
