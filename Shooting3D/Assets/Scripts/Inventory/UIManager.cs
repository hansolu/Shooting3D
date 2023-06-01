using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class UIManager : SingletonMono<UIManager>
{
    //유아이 종류별로 하나씩 들구있음.
    public Canvas canvas;
    Dictionary<CTEnum.UIInvenKind, InventoryUI> InventoryUIDic = new Dictionary<CTEnum.UIInvenKind, InventoryUI>();

    [SerializeField]
    PickUpItemUI TempItemUI; //들고있는 클릭중인 드래그중인 아이템 그려내는 ui

    public GameObject PlayerBagPrefab; //사람의 인벤토리 ui프리팹
    public GameObject StoragePrefab; //보관함의 인벤토리 ui프리팹

    public GameObject SlotPrefab; //슬롯 프리팹
    public int SlotLayer=0;

    protected override void Init() 
    {
        SlotLayer = 1 << LayerMask.NameToLayer("Slot");
        GameObject tempobj = Instantiate(PlayerBagPrefab, canvas.transform);
        InventoryUI tempInvenUi;
        if (tempobj.TryGetComponent<InventoryUI>(out tempInvenUi))
        {
            InventoryUIDic.Add(CTEnum.UIInvenKind.Player, tempInvenUi);
        }

        // tempobj = Instantiate(StoragePrefab, this.transform);
        //if (TryGetComponent<InventoryUI>(out tempInvenUi))
        //{
        //    InventoryUIDic.Add(CTEnum.UIInvenKind.Storage, tempInvenUi);
        //}

        //for (int i = 0; i < InventoryUIDic.Count; i++)
        //{
        //    InventoryUI_IsOpen.Add(false);
        //}

        TempItemUI.Init();

        base.Init();        
    }         
   
    public void ActivateInvenUI(bool _on, CTEnum.UIInvenKind _kind, int _invenidx) //인벤토리 자체 창을 열었음.
    {
        if (InventoryUIDic.ContainsKey(_kind)) //해당 종류의 창이 존재한다면
        {
            InventoryUIDic[_kind].IsOpen = _on;
            InventoryUIDic[_kind].gameObject.SetActive(_on); //창의 활성화
            if (_on)
            {
                InventoryUIDic[_kind].Init(InvenManager.Instance.GetInven(_invenidx).InvenCount,
                    _invenidx);
            }            
        }
        
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
    public void DrawSlot(CTEnum.UIInvenKind _kind, int _slotnum, Item _iteminfo)
    {
        if (InventoryUIDic.ContainsKey(_kind)) //해당 종류의 창이 존재한다면
        {
            if (InventoryUIDic[_kind].IsOpen == false)//만약 창이 비활성화 되어있다면 그냥 return
            {
                return;
            }

            //창이 활성화 되어있음
            //해당 slot을 그려냄.

            InventoryUIDic[_kind].DrawSlot(_slotnum, _iteminfo);
        }
    }

    //아이템 드래그표현 2번 코루틴으로 혹은 업데이트 같은데에서 TEmpItemUI를 이동시키는 작업을 함.
    //아이템 드래그표현 3번 TempItemUI 의 위치를 조정

    public void SetTempItemUIActive(bool _on, Sprite _spr=null)
    {
        TempItemUI.gameObject.SetActive(_on);
        TempItemUI.SetImage(_spr);
        TempItemUI.transform.SetAsLastSibling();
    }
    public void SetTempItemUIPosition(Vector2 _pos)
    {
        TempItemUI.transform.position = _pos;
    }
}
