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
                AllInventoryDic[_invenidx].AddSimple(_item); //���� �����ʰ� ���ϱ�
            }
            else
            {
                AllInventoryDic[_invenidx].AddSlot(_slotnum, _item); //���� �����ؼ� ���ϱ�
            }                        
        }
    }
        
    public void SubItem(int _invenidx, int _slotnum /*= -1*/, Item _item = null) //_item�� ���� ã�� ���� �������� �ε����� ���� ������ ��Ƴ��ߵ�.
    {
        if (AllInventoryDic.ContainsKey(_invenidx))
        {
            //���� �����ؼ� ���°�
            if (_slotnum >= 0 || _slotnum < AllInventoryDic[_invenidx].InvenCount) 
            {
                AllInventoryDic[_invenidx].SubSlot(_slotnum); //�ش� ���� ����
            }
            else
            {
                //���� �����ʰ� ���°�.
                if (_item !=null && _item.Count > 0)
                {
                    //Ư�� �������� ���ڴ�...

                    AllInventoryDic[_invenidx].SubSimple(_item.Index, _item.Count);//���� ������� ������ ����
                }                
            }
        }
    }

    public void SwapSlot(SlotUI _startslot, SlotUI _endslot)
    {
        if (_startslot.IsExist ==false) //���۽��Ժ��� ����ִٸ� �ǹ̾���.
        {
            return;
        }
        else
        {
            if (_endslot.IsExist) //�ٲ������.
            {//���� ��� 0�� //�� ���� 1������
                //startslot�� �ش�Ǵ� ������ ����.                
                Item iteminfo_start = new Item(GetItemInfo(_startslot.InventoryIndex, _startslot.SlotIndex));                 
                Item iteminfo_end = new Item( GetItemInfo(_endslot.InventoryIndex, _endslot.SlotIndex));

                SubItem(_startslot.InventoryIndex ,_startslot.SlotIndex); //���� ���� ������ ����
                SubItem(_endslot.InventoryIndex, _endslot.SlotIndex); //�� ���� ������ ����

                AddItem(iteminfo_start, _endslot.InventoryIndex, _endslot.SlotIndex); //�� ���Կ��ٰ� ���۽��� ������ ���� ����               
                AddItem(iteminfo_end, _startslot.InventoryIndex, _startslot.SlotIndex); //�� ���Կ��ٰ� ���۽��� ������ ���� ����               

            }
            else //�׳� �̵������ָ� ��
            {
                //startslot�� �ش�Ǵ� ������ ����.
                Item iteminfo = GetItemInfo(_startslot.InventoryIndex, _startslot.SlotIndex);
                AddItem(iteminfo, _endslot.InventoryIndex, _endslot.SlotIndex); //�� ���Կ��ٰ� ���۽��� ������ ���� ����
                SubItem(_startslot.InventoryIndex, _startslot.SlotIndex); //���� ���� ������ ����                
            }
            //UI�Ŵ����� ���ؼ� �۾��ϴ���
            UIManager.Instance.DrawSlot(_endslot.UIInvenKind, _endslot.SlotIndex,
               AllInventoryDic[_endslot.InventoryIndex].GetItemInfo(_endslot.SlotIndex));
            UIManager.Instance.DrawSlot(_startslot.UIInvenKind, _startslot.SlotIndex,
               AllInventoryDic[_startslot.InventoryIndex].GetItemInfo(_startslot.SlotIndex));

            //�̹� ���� ���Կ� �����Ҽ� �ִ� ������ �������� �ٷ� ����
            //_startslot.SetItemDraw();
        }
    }                     

    //public void SetUIDrawSlot() //�������� �ٲ�� ������Ʈ ��
    //{
    //}
}
