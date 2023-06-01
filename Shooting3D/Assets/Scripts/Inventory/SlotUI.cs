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

    public bool IsExist = false; //�� ������ ����ִ��� ä�����ִ���
   
    //���� ���� ����
    public void Init(CTEnum.UIInvenKind _uiInvenKind, int _inventoryIdx, int _slotIndex)
    {
        UIInvenKind = _uiInvenKind;
        InventoryIndex = _inventoryIdx;
        SlotIndex = _slotIndex;
        SetNullRef();

        Item iteminfo = InvenManager.Instance.GetItemInfo(_inventoryIdx,_slotIndex);

        if (iteminfo.Count <= 0) //�����
        {
            SetItemDraw(false, null, "0");            
        }
        else //�����Ѵ�
        {
            Debug.Log("����ui �׷�����");
            SetItemDraw(true, 
                ResourceManager.Instance.ItemSprites[(int)iteminfo.Index] , 
                iteminfo.Count.ToString());
        }        
    }

    //���� �ϳ��ϳ� �����
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
        else //������ϸ�
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

    //����Ŭ�� ��� / ����Ŭ�� �ؼ� �޴� ���.. �ϰ� ����ϱ� ������...
    //�巡��..
    public void OnPointerClick(PointerEventData eventData)
    {
        //Ŭ���� ������ �Ҹ�
        //Debug.Log(SlotIndex + "Ŭ���������� ��ġ�� " + eventData.position);
        //if (eventData.clickCount >=2)
        //{
        //    Debug.Log("����Ŭ��");  
        //}
        //else
        //{
        //    Debug.Log("�Ϲ�Ŭ��"); //
        //}
    }

    public void OnBeginDrag(PointerEventData eventData) //������ ����ø���
    {
        //�巡�װ� �� ��ũ��Ʈ���� ���۵ƴٸ� �Ҹ�
        //Debug.Log(SlotIndex + "OnBeginDrag ��ġ�� " + eventData.position);

        //�κ��丮 
        //���� �����Ͱ��־ ������ �Űܾ� �ϴ� ������, Ȥ�� ����־ �巡�� �ص� �ƹ��� ����� �ϴ� ������
        if (IsExist ==false)
        {
            return;
        }

        UIManager.Instance.SetTempItemUIActive(true, ItemImg.sprite);

        ItemImg.gameObject.SetActive(false);

        //������ �巡��ǥ�� 2�� UI�Ŵ����� �Լ� �� �ڷ�ƾ �ݸ� 1ȸ
    }

    public void OnDrag(PointerEventData eventData) //�������� �̵�
    {
        if (IsExist == false)
        {
            return;
        }
        //�巡�װ� �������̶�� �Ҹ�
        //Debug.Log(SlotIndex + "OnDrag ��ġ�� " + eventData.position);

        UIManager.Instance.SetTempItemUIPosition(eventData.position);
        //UIManager.Instance.TempItemUI.transform.position = eventData.position;

        //������ �巡��ǥ�� 1�� ���⼭ �ٷ� UI�Ŵ����� TempItemUI�� ����ؼ� ���� ��ġ�� �ٲ��ش�     
        //������ �巡��ǥ�� 3�� UI�Ŵ����� TempItemUI��ġ �����϶�� ��� �ݸ���.
    }

    public void OnEndDrag(PointerEventData eventData) //������ �������� 
    {
        if (IsExist == false)
        {
            return;
        }

        UIManager.Instance.SetTempItemUIActive(false);
        //UIManager.Instance.TempItemUI.gameObject.SetActive(false);

        //�巡�װ� ��������
        //�ش� �������� �׸� �������ְ�.
        //�����͵� ��ü �ʿ�.

        TempNextSlot = null;

        //#########�ٸ� ����̾����Ͱ����� �ٽ� �˾ƿðԿ�...
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

        if (TempNextSlot ==null) //ó���� �巡�� ������ �������̾�����, �巡���� ���� ���� ���� �ƴѰ��.
        {
            //������ ������ ���.

            //�츮�� ����� �ϴ� �����ϱ� ���� �������� ���������ٰ� ġ��.
            ItemImg.gameObject.SetActive(true);
            return;
        }

        InvenManager.Instance.SwapSlot(this, TempNextSlot);

        //�巡�װ� �����ٸ� �Ҹ�
        //Debug.Log(SlotIndex + "OnEndDrag ��ġ�� " + eventData.position);
    }

    //public void 
}
