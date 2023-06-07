using System.Collections;
using System.Collections.Generic;

public class Inventory //인벤토리 매니저를 따로 두든 / 각 객체에 달아놓든.. 
{

    /*
     * 이 인벤토리 스크립트는
     * 사람이건, 보관함이건 상관없고
     * 아이템 딕셔너리(ItemDic)를 들고 있는, 데이터로써의 인벤토리
     * 인벤토리간 구분 및 검색은 Index로 접근하며
     * 인벤토리의 전체 크기는 InvenCount로 알 수 있음.
     * 더하기, 빼기 기본 기능 및 Get~으로 데이터 가져오기 가능.
     */

    public CTEnum.UIInvenKind InvenKind { get; private set; } //사람의 인벤인지 보관함인지 뭔가.. 
    public int Index { get; private set; } = 0; //인벤토리의 고유번호 //인벤토리 고유번호 관리하는 부분이 어디 따로있어야할것.
    public int InvenCount { get; private set; } = 0; //인벤의 슬롯 최대칸수
    //public int InvenCount => ItemDic.Count;

    ////만약 아이템 칸을 반드시 한정 짓고 싶고, 한정지어서 편하게 관리 하고싶다. //포문가능
    //Item[] ItemArr;//= new Item[10];  // 0 0 0 0 0 
    //                                  // 0 0 0 0 0

    ////자동정렬 및 인벤토리 가변성 있음
    List<Item> ItemList = new List<Item>(); //Item 이 count가 0이됐을떄 없애지 않는 경우가 아니라면
    ////왠만하면 순서대로 값이 다 차있어서 //여튼 count로 포문 돌리기가 가능
    
    //자동정렬 없고 가변적인 배열처럼 관리하고 싶음. //근데 얘는 포문 안됨....유의
    Dictionary<int, Item> ItemDic = new Dictionary<int, Item>(); // 


    //내가 소유한 아이템의 Index정보만 따로 빼서 관리...


    public void Init(CTEnum.UIInvenKind _kind, int invencount, int Index=-1) //처음 세팅
    {
        if (Index >= 0)
        {
            this.Index = Index;
        }
        InvenCount = invencount;
        for (int i = 0; i < InvenCount; i++)
        {
            ItemDic.Add(i, /*null*/new Item()); //슬롯이자 아이템 정보... 
            //나의 아이템 컬렉션 채우기...
        }
    }

    //public void InitLoad() //불러오기 적용 하게되면 채울것임..
    //{
    //}

    public List<Item> GetAllItemInfo()
    {
        List<Item> returnList = new List<Item>();
        for (int i = 0; i < InvenCount; i++)
        {
            returnList.Add(ItemDic[i]);
        }
        return returnList;
    }

    public Item GetItemInfo(int slotnum)
    {
        return ItemDic[slotnum];
    }

    //아이템 더하기 //그냥 줍는 경우 / 드래그로 더하는 경우.. (직접 더하는 경우) 
    //아이템 빼기 //구매같이 자동으로 빼는 경우... 클릭해서 옮기느라 빠지는 경우.
    //자동정렬...

    public void AddSimple(Item _item) //슬롯 몇번 정보 이런거 필요없이 그냥 줍기
    {
        //무조건 같은 물건이 있으면 그 칸 다 채우고 나머지 뭘하기..        
        for (int i = 0; i < InvenCount; i++)
        {
            if (ItemDic[i].Index == _item.Index) //같은 아이템
            {
                if (ItemDic[i].AbleCount >= _item.Count) //그대로 넣을수 있음.
                {
                    _item.SetCount(ItemDic[i].AddCount(_item.Count));                    
                    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // 인벤토리 고유번호, 슬롯번호, 아이템정보..
                    break;
                }
                //else //많아서 나머지는 다른칸에 마저 넣어야함.
                //{
                //    _item.SetCount( ItemDic[i].AddCount(_item.Count));
                //    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // 인벤토리 고유번호, 슬롯번호, 아이템정보..
                //}                
            }            
        }

        if (_item.Count > 0) //못넣은 개수가 있다
        {
            for (int i = 0; i < InvenCount; i++)
            {
                if (ItemDic[i].Count == 0) //비어있는 칸.
                {
                    ItemDic[i].SetItem(_item);
                    _item.SetCount(0);

                    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // 인벤토리 고유번호, 슬롯번호, 아이템정보..
                    break;
                }
            }

            if (_item.Count > 0)
            {
                //바닥에 버리기...
                //만약 아이템 매니저가 있어서 드랍아이템을 따로 생성하고 관리하고 한다면 걔한테 요청 =>이게 나음.
                //그게 아니라면 모노비헤이비어 상속받고 Instantiate해서 아이템 생성 및 드랍 하기...
            }
        }
        
        //UIManager.Instance.Redraw(); //여튼 나 인벤 바뀌었으니까 다시 다 그려줘.
    }

    public Item AddSlot(int slotnum, Item _item)//특정 슬롯에다가 내가 더하는 행위를 했음.
    {        
        if (ItemDic[slotnum].Index == _item.Index) //같은 아이템
        {
            //판별해서 그냥 더해줌
            int overnum = ItemDic[slotnum].AddCount(_item.Count); //더한 개수가 Max를 넘겼으면 overnum이 0보다 클것.
            _item.SetCount(overnum);
        }        
        else  //인덱스가 다름
        {
            if (ItemDic[slotnum].Count == 0 ) //비어있음
            {
                ItemDic[slotnum].SetItem(_item); //빈칸에 아이템 복사해서 넣기
                _item.SetCount(0); //내 아이템은 비우기.
            }
            else //아예 다른 물건이 차있음.
            {
                //스왑해주기...
                Item tempItem = new Item();
                tempItem.SetItem( ItemDic[slotnum]); //
                ItemDic[slotnum].SetItem(_item); //지금 매개변수로 들어온 아이템을 아이템 딕셔너리에 채워줌
                _item.SetItem(tempItem); //스왑완료
            }
        }

        //if (_item.Count > 0) //더하고 뭐했는데 손에 아직 물건 들고 있음
        //{            
        //}
        return _item; //이거는 받는 쪽에서 아직 들고있는지 아닌지 판별하게 합시다.
    }

    //public bool IsExist(int index, int count)
    //{ 
    //    //내 인벤 검색해서
    //    //해당 index 아이템이 있는지, count 개수만큼 있는게 맞는지

    //    //그 여부 리턴
    //}

    public int GetIsAbleCount(int index)
    {
        int isablecount = 0;
        for (int i = 0; i < InvenCount; i++)
        {
            if (ItemDic[i].Index == index)
            {
                isablecount += ItemDic[i].Count;
            }
        }
        return isablecount;
    }
    public bool SubSimple(int itemIndex, int count ) //제작 내지 상점에서 거래.. 내가 가진 아이템중 특정 아이템과 특정 개수판별
    {        
        int isablecount = GetIsAbleCount(itemIndex);        
        
        //내가 가진것 다 검색..
        if (isablecount < count)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < InvenCount; i++)
            {
                if (ItemDic[i].Index == itemIndex)
                {
                    count = ItemDic[i].SubCount(count);
                    if (count == 0)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }

    public Item SubSlot(int slotnum) //특정 슬롯째로 빼기.
    {        
        Item temp = new Item();
        temp.SetItem(ItemDic[slotnum]);
        ItemDic[slotnum].Clear();
        return temp;
    }
}
