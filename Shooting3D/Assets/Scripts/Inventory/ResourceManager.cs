using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ResourceManager : SingletonMono<ResourceManager>
{
    public Sprite[] ItemSprites;
    //자잘한 프리팹
    public GameObject ItemPrefab;
    public Item CreateItem(CTEnum.ItemKind _kind, int _index)
    {
        return new Item(_kind, _index, 1, 5);
    }
}
