using System.Collections;
using System.Collections.Generic;
using Singleton;

public class InvenManager : Singleton<InvenManager> //
{    
    public static int LastInventoryIdx = 0; //인벤토리 고유 인덱스 부여 하기 위함.
    Dictionary<int, Inventory> AllInventoryDic = new Dictionary<int, Inventory>(); //모든 인벤토리 정보.
    
    //인벤토리 생성 
    
    public void CreateInven(CTEnum.UIInvenKind _kind, int invencount) //인벤칸 개수 지정해주기
    {
        LastInventoryIdx++;
        AllInventoryDic.Add(LastInventoryIdx, new Inventory());
        AllInventoryDic[LastInventoryIdx].Init(_kind, invencount, LastInventoryIdx);
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
    
    //인벤토리 활성화 키 누르면...
    public void SetUIInventoryOpen(int invenidx) //인벤토리 인덱스를 매개변수로 함수 한번 콜링하면 일단 그 인벤토리 ui활성화 시켜줘.
    {
        Item tempItem;
        if (AllInventoryDic.ContainsKey(invenidx))
        {
            UIManager.Instance.ActivateInvenUI(AllInventoryDic[invenidx].InvenKind);

            for (int i = 0; i < AllInventoryDic[invenidx].InvenCount; i++)
            {
                tempItem = AllInventoryDic[invenidx].GetItemInfo(i);
                UIManager.Instance.DrawSlot(AllInventoryDic[invenidx].InvenKind, i,
                    tempItem); //슬롯 하나하나 그려낼 것.
            }            
        }
    }
    public void SetUIDrawSlot() //슬롯정보 바뀐거 업데이트 용
    {

    }
}
