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
                AllInventoryDic[_invenidx].AddSimple(_item); //슬롯 지정않고 더하기
            }
            else
            {
                AllInventoryDic[_invenidx].AddSlot(_slotnum, _item); //슬롯 지정해서 더하기
            }                        
        }
    }
        
    public void SubItem(int _invenidx, int _slotnum /*= -1*/, Item _item = null) //_item은 내가 찾고 싶은 아이템의 인덱스와 개수 정보를 담아놔야됨.
    {
        if (AllInventoryDic.ContainsKey(_invenidx))
        {
            //슬롯 지정해서 빼는것
            if (_slotnum >= 0 || _slotnum < AllInventoryDic[_invenidx].InvenCount) 
            {
                AllInventoryDic[_invenidx].SubSlot(_slotnum); //해당 슬롯 빼기
            }
            else
            {
                //슬롯 지정않고 빼는것.
                if (_item !=null && _item.Count > 0)
                {
                    //특정 아이템을 빼겠다...

                    AllInventoryDic[_invenidx].SubSimple(_item.Index, _item.Count);//슬롯 상관없이 아이템 빼기
                }                
            }
        }
    }

    public void SwapSlot(SlotUI _startslot, SlotUI _endslot)
    {
        if (_startslot.IsExist ==false) //시작슬롯부터 비어있다면 의미없음.
        {
            return;
        }
        else
        {
            if (_endslot.IsExist) //바꿔줘야함.
            {//시작 사과 0번 //끝 갑옷 1번슬롯
                //startslot에 해당되는 아이템 정보.                
                Item iteminfo_start = new Item(GetItemInfo(_startslot.InventoryIndex, _startslot.SlotIndex));                 
                Item iteminfo_end = new Item( GetItemInfo(_endslot.InventoryIndex, _endslot.SlotIndex));

                SubItem(_startslot.InventoryIndex ,_startslot.SlotIndex); //시작 슬롯 데이터 삭제
                SubItem(_endslot.InventoryIndex, _endslot.SlotIndex); //끝 슬롯 데이터 삭제

                AddItem(iteminfo_start, _endslot.InventoryIndex, _endslot.SlotIndex); //끝 슬롯에다가 시작슬롯 아이템 정보 더함               
                AddItem(iteminfo_end, _startslot.InventoryIndex, _startslot.SlotIndex); //끝 슬롯에다가 시작슬롯 아이템 정보 더함               

            }
            else //그냥 이동시켜주면 됨
            {
                //startslot에 해당되는 아이템 정보.
                Item iteminfo = GetItemInfo(_startslot.InventoryIndex, _startslot.SlotIndex);
                AddItem(iteminfo, _endslot.InventoryIndex, _endslot.SlotIndex); //끝 슬롯에다가 시작슬롯 아이템 정보 더함
                SubItem(_startslot.InventoryIndex, _startslot.SlotIndex); //시작 슬롯 데이터 삭제                
            }
            //UI매니저를 통해서 작업하던지
            UIManager.Instance.DrawSlot(_endslot.UIInvenKind, _endslot.SlotIndex,
               AllInventoryDic[_endslot.InventoryIndex].GetItemInfo(_endslot.SlotIndex));
            UIManager.Instance.DrawSlot(_startslot.UIInvenKind, _startslot.SlotIndex,
               AllInventoryDic[_startslot.InventoryIndex].GetItemInfo(_startslot.SlotIndex));

            //이미 내게 슬롯에 접근할수 있는 권한이 생겼으니 바로 가능
            //_startslot.SetItemDraw();
        }
    }                     

    //public void SetUIDrawSlot() //슬롯정보 바뀐거 업데이트 용
    //{
    //}
}
