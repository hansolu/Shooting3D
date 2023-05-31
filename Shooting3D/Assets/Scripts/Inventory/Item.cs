using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class FoodItem : Item 
//{ }
//public class Weapon : Item //Ȱ, �� = ������ ������... , ������...
//{
//    public CTEnum.WeaponKind weaponKind;
//    public Weapon(���̽������� �޾ƿ�)
//    {
//        weaponKind = (CTEnum.WeaponKind)���̽�������.specificKind;
//    }
//}
public class Item  //�굵 �Ŀ� ���� �� ���������̺����� ���� ���� ���� �����ϸ� ����ItemData�� ����ϴ�ItemData�� ������..
{    
    //������ ������
    //public bool IsEmpty => Index == -1;
    public CTEnum.ItemKind itemKind = CTEnum.ItemKind.End;        
    public int Index { get; private set; } //���� �������ε���
    public int MaxCount { get; private set; } = 0; //public �̹Ƿ� �����ؾ���. �����Ҽ� �ִ� �ִ� ������ ����

    //���Կ����� ���
    public int Count { get; private set; } = 0; //public �̹Ƿ� �����ؾ���. ���� ���� �����ϰ� �ִ� ������ ����    
    

    public int AbleCount => MaxCount - Count;//�� ���� �ʿ����. ���

    public Item() //������. �� ������ ����
    {
        Clear();
    }

    public Item(CTEnum.ItemKind itemkind, int index, int count, int maxcount) //���� ������ �ε��
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
        Index = -1; //���� �� �����۵� �������� 1������ ����...
    }
    public void SetItem(Item item) //������ ������ ���� �ٲ���.
    {
        itemKind = item.itemKind;
        Count = item.Count;
        Index = item.Index;
        MaxCount = item.MaxCount;
    }
    public void SetCount(int count) //������ ���� �ٲ�
    {        
        Count = count; 
    }

    public int AddCount(int addcount) //�� ���������� 0 �� ��ȯ, �ʰ��ߴٸ� �ʰ��� ������ ��ȯ
    {
        Count += addcount;
        if (Count > MaxCount)
        {
            int returncount = MaxCount - Count;

            Count = MaxCount;
            //Debug.LogError($"�ִ� ������ {MaxCount}�� �ε� ���� ������ {Count}�� ��");
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
            //Debug.LogError($"���� ������ {Count}�� ��");
            return returncount;
        }
        else
        {            
            return 0;
        }
    }
}
