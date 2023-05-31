using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class UIManager : SingletonMono<UIManager>
{  
    //유아이 종류별로 하나씩 들구있음.
    Dictionary<CTEnum.UIInvenKind, InventoryUI> InventoryUIDic = new Dictionary<CTEnum.UIInvenKind, InventoryUI>();

    public ItemUI TempItemUI; //들고있는 클릭중인 드래그중인 아이템 그려내는 ui

    public GameObject PlayerBagPrefab; //사람의 인벤토리 ui프리팹
    public GameObject StoragePrefab; //보관함의 인벤토리 ui프리팹

    protected override void Init()
    {
        GameObject tempobj = Instantiate(PlayerBagPrefab, this.transform);
        InventoryUI tempInvenUi;
        if (TryGetComponent<InventoryUI>(out tempInvenUi))
        {
            InventoryUIDic.Add(CTEnum.UIInvenKind.Player, tempInvenUi);
        }


         tempobj = Instantiate(StoragePrefab, this.transform);        
        if (TryGetComponent<InventoryUI>(out tempInvenUi))
        {
            InventoryUIDic.Add(CTEnum.UIInvenKind.Storage, tempInvenUi);
        }

        //for (int i = 0; i < InventoryUIDic.Count; i++)
        //{
        //    InventoryUI_IsOpen.Add(false);
        //}
        
        base.Init();        
    }         
   
    public void ActivateInvenUI(CTEnum.UIInvenKind _kind) //인벤토리 자체 창을 열었음.
    {
        //같은 종류의 인벤창은 열리지 않는 것으로 함.
        //if (IsOpen(_kind)) 
        //{
        //    //이미 열려있다면 새로운 정보로 덮어쓰기
        //}
        //else //안열렸다면 열기
        //{
            
        //}
    }

    //forceopen이 트루일경우 닫혀있었다면 강제로 열고 그리기. 
    public void DrawSlot(CTEnum.UIInvenKind kind, int slotnum, Item iteminfo)
    {
        //만약 창이 비활성화 되어있다면 그냥 return
        //창이 활성화 되어있다면
        //해당 slot을 그려냄.
        
    }


}
