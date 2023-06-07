using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ResourceManager : SingletonMono<ResourceManager>
{
    public Sprite[] ItemSprites;
    //������ ������
    public GameObject ItemPrefab;

    //������ ���̺��� �����͵� �� ������ ����...
    //ItemData[] Itemdatas; //���̽� ���� �ε��� ������ ���̺��� ������ ����������...

    public Item CreateItem(CTEnum.ItemKind _kind, int _index)
    {
        return new Item(_kind, _index, 1, 5);
    }
}

//���������� ������ ������..
public class ItemData
{
    public CTEnum.ItemKind itemKind = CTEnum.ItemKind.End;
    public int Index { get; private set; } //���� �������ε���
    public int MaxCount { get; private set; } = 0; //public �̹Ƿ� �����ؾ���. �����Ҽ� �ִ� �ִ� ������ ����
}