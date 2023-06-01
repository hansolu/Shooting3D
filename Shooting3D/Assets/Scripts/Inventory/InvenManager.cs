using System.Collections;
using System.Collections.Generic;
using Singleton;

public class InvenManager : Singleton<InvenManager> //
{    
    public static int LastInventoryIdx = 0; //�κ��丮 ���� �ε��� �ο� �ϱ� ����.
    Dictionary<int, Inventory> AllInventoryDic = new Dictionary<int, Inventory>(); //��� �κ��丮 ����.
    
    //�κ��丮 ���� 
    
    public int CreateInven(CTEnum.UIInvenKind _kind, int invencount) //�κ�ĭ ���� �������ֱ�
    {
        LastInventoryIdx++;
        AllInventoryDic.Add(LastInventoryIdx, new Inventory());
        AllInventoryDic[LastInventoryIdx].Init(_kind, invencount, LastInventoryIdx);
        return LastInventoryIdx;
    }

    //�κ����� ��������.
    public Inventory GetInven(int invenidx) //�����κ��丮 ��ȣ�� �κ� ��������
    {
        if (AllInventoryDic.ContainsKey(invenidx))
        {
            return AllInventoryDic[invenidx];
        }
        else
        {
            throw new System.Exception($"{invenidx}�� ���� �κ���ȣ");
        }
    }

    public Item GetItemInfo(int _invenidx, int _slotidx)
    {
        if (AllInventoryDic.ContainsKey(_invenidx))
        {
            if (AllInventoryDic[_invenidx].InvenCount > _slotidx)
            {
                return AllInventoryDic[_invenidx].GetItemInfo(_slotidx);
            }            
        }


        return /*null*/new Item();
    }

    public void AddItem(Item _item, int _invenidx, int _slotnum = -1) //���Գѹ��� �������� �ʴ´ٸ� -1�� ����Ʈ ��. ���Գѹ��� -1�̶�� �ܼ����ϱ� �ϸ��.
    {
        if (AllInventoryDic.ContainsKey(_invenidx))
        {
            if (_slotnum <= 0 || _slotnum >= AllInventoryDic[_invenidx].InvenCount) //�����Ҽ� ���� ���� ��ȣ��...
            {
                AllInventoryDic[_invenidx].AddSimple(_item);
            }
            else
            {
                AllInventoryDic[_invenidx].AddSlot(_slotnum, _item);
            }                        
        }
    }

    public void SwapSlot(SlotUI _startslot, SlotUI _endslot)
    {

    }                     

    //public void SetUIDrawSlot() //�������� �ٲ�� ������Ʈ ��
    //{
    //}
}
