using System.Collections;
using System.Collections.Generic;
using Singleton;

public class InvenManager : Singleton<InvenManager> //
{    
    public static int LastInventoryIdx = 0; //인벤토리 고유 인덱스 부여 하기 위함.
    Dictionary<int, Inventory> AllInventoryDic = new Dictionary<int, Inventory>(); //모든 인벤토리 정보.
    
    //인벤토리 생성 
    
    public int CreateInven(CTEnum.UIInvenKind _kind, int invencount) //인벤칸 개수 지정해주기
    {
        LastInventoryIdx++;
        AllInventoryDic.Add(LastInventoryIdx, new Inventory());
        AllInventoryDic[LastInventoryIdx].Init(_kind, invencount, LastInventoryIdx);
        return LastInventoryIdx;
    }

    //인벤정보 가져오기.
    public Inventory GetInven(int invenidx) //고유인벤토리 번호로 인벤 가져오기
    {
        if (AllInventoryDic.ContainsKey(invenidx))
        {
            return AllInventoryDic[invenidx];
        }
        else
        {
            throw new System.Exception($"{invenidx}는 없는 인벤번호");
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

    public void AddItem(Item _item, int _invenidx, int _slotnum = -1) //슬롯넘버를 지정하지 않는다면 -1이 디폴트 값. 슬롯넘버가 -1이라면 단순더하기 하면됨.
    {
        if (AllInventoryDic.ContainsKey(_invenidx))
        {
            if (_slotnum <= 0 || _slotnum >= AllInventoryDic[_invenidx].InvenCount) //접근할수 없는 슬롯 번호임...
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

    //public void SetUIDrawSlot() //슬롯정보 바뀐거 업데이트 용
    //{
    //}
}
