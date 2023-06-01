using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    CTEnum.UIInvenKind UIInvenKind;
    public int InventoryIndex = 0; 
    public int SlotIndex = 0;

    Image ItemImg = null;
    Text ItemTxt = null;

    SlotUI TempNextSlot = null;

    public bool IsExist = false; //이 슬롯이 비어있는지 채워져있는지
   
    //슬롯 정보 세팅
    public void Init(CTEnum.UIInvenKind _uiInvenKind, int _inventoryIdx, int _slotIndex)
    {
        UIInvenKind = _uiInvenKind;
        InventoryIndex = _inventoryIdx;
        SlotIndex = _slotIndex;
        SetNullRef();

        Item iteminfo = InvenManager.Instance.GetItemInfo(_inventoryIdx,_slotIndex);

        if (iteminfo.Count <= 0) //비었다
        {
            SetItemDraw(false, null, "0");            
        }
        else //존재한다
        {
            Debug.Log("슬롯ui 그려내기");
            SetItemDraw(true, 
                ResourceManager.Instance.ItemSprites[(int)iteminfo.Index] , 
                iteminfo.Count.ToString());
        }        
    }

    //슬롯 하나하나 변경시
    public void SetItemDraw(bool _isExist, Sprite _spr, string _count)
    {
        SetNullRef();
        IsExist = _isExist;
        if (IsExist)
        {
            ItemImg.gameObject.SetActive(true);
            ItemImg.sprite = _spr;
            ItemTxt.text = _count;
        }
        else //존재안하면
        {
            ItemImg.gameObject.SetActive(false);
            ItemImg.sprite = null;
            ItemTxt.text = "";
        }
    }

    void SetNullRef()
    {
        if (ItemImg == null)
        {
            ItemImg = transform.GetChild(0).GetComponent<Image>();
        }
        if (ItemTxt == null)
        {
            ItemTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        }
    }

    //더블클릭 사용 / 오른클릭 해서 메뉴 띄움.. 하고 사용하기 버리기...
    //드래그..
    public void OnPointerClick(PointerEventData eventData)
    {
        //클릭이 들어오면 불림
        //Debug.Log(SlotIndex + "클릭했을때의 위치값 " + eventData.position);
        //if (eventData.clickCount >=2)
        //{
        //    Debug.Log("더블클릭");  
        //}
        //else
        //{
        //    Debug.Log("일반클릭"); //
        //}
    }

    public void OnBeginDrag(PointerEventData eventData) //아이템 집어올리기
    {
        //드래그가 이 스크립트에서 시작됐다면 불림
        //Debug.Log(SlotIndex + "OnBeginDrag 위치값 " + eventData.position);

        //인벤토리 
        //내가 데이터가있어서 실제로 옮겨야 하는 애인지, 혹은 비어있어서 드래그 해도 아무일 없어야 하는 애인지
        if (IsExist ==false)
        {
            return;
        }

        UIManager.Instance.SetTempItemUIActive(true, ItemImg.sprite);

        ItemImg.gameObject.SetActive(false);

        //아이템 드래그표현 2번 UI매니저의 함수 및 코루틴 콜링 1회
    }

    public void OnDrag(PointerEventData eventData) //아이템의 이동
    {
        if (IsExist == false)
        {
            return;
        }
        //드래그가 진행중이라면 불림
        //Debug.Log(SlotIndex + "OnDrag 위치값 " + eventData.position);

        UIManager.Instance.SetTempItemUIPosition(eventData.position);
        //UIManager.Instance.TempItemUI.transform.position = eventData.position;

        //아이템 드래그표현 1번 여기서 바로 UI매니저의 TempItemUI를 사용해서 직접 위치를 바꿔준다     
        //아이템 드래그표현 3번 UI매니저의 TempItemUI위치 조정하라고 계속 콜링함.
    }

    public void OnEndDrag(PointerEventData eventData) //아이템 내려놓기 
    {
        if (IsExist == false)
        {
            return;
        }

        UIManager.Instance.SetTempItemUIActive(false);
        //UIManager.Instance.TempItemUI.gameObject.SetActive(false);

        //드래그가 끝났을때
        //해당 슬롯으로 그림 전달해주고.
        //데이터도 교체 필요.

        TempNextSlot = null;

        //#########다른 방법이었던것같은데 다시 알아올게요...
        var result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        for (int i = 0; i < result.Count; i++)
        {
            if (result[i].gameObject.GetComponent<SlotUI>())
            {
                TempNextSlot = result[i].gameObject.GetComponent<SlotUI>();
                break;
            }
        }

        if (TempNextSlot ==null) //처음에 드래그 시작은 정상적이었지만, 드래그의 끝이 슬롯 위가 아닌경우.
        {
            //보통은 아이템 드랍.

            //우리는 드랍이 일단 없으니까 원래 슬롯으로 돌려보낸다고 치자.
            ItemImg.gameObject.SetActive(true);
            return;
        }

        InvenManager.Instance.SwapSlot(this, TempNextSlot);

        //드래그가 끝났다면 불림
        //Debug.Log(SlotIndex + "OnEndDrag 위치값 " + eventData.position);
    }

    //public void 
}
