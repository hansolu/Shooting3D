using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class UIManager : SingletonMono<UIManager>
{
    //������ �������� �ϳ��� �鱸����.
    public Canvas canvas;
    Dictionary<CTEnum.UIInvenKind, InventoryUI> InventoryUIDic = new Dictionary<CTEnum.UIInvenKind, InventoryUI>();

    [SerializeField]
    PickUpItemUI TempItemUI; //����ִ� Ŭ������ �巡������ ������ �׷����� ui

    public GameObject PlayerBagPrefab; //����� �κ��丮 ui������
    public GameObject StoragePrefab; //�������� �κ��丮 ui������

    public GameObject SlotPrefab; //���� ������
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
   
    public void ActivateInvenUI(bool _on, CTEnum.UIInvenKind _kind, int _invenidx) //�κ��丮 ��ü â�� ������.
    {
        if (InventoryUIDic.ContainsKey(_kind)) //�ش� ������ â�� �����Ѵٸ�
        {
            InventoryUIDic[_kind].IsOpen = _on;
            InventoryUIDic[_kind].gameObject.SetActive(_on); //â�� Ȱ��ȭ
            if (_on)
            {
                InventoryUIDic[_kind].Init(InvenManager.Instance.GetInven(_invenidx).InvenCount,
                    _invenidx);
            }            
        }
        
        //���� ������ �κ�â�� ������ �ʴ� ������ ��.
        //if (IsOpen(_kind)) 
        //{
        //    //�̹� �����ִٸ� ���ο� ������ �����
        //}
        //else //�ȿ��ȴٸ� ����
        //{

        //}
    }

    //forceopen�� Ʈ���ϰ�� �����־��ٸ� ������ ���� �׸���. 
    public void DrawSlot(CTEnum.UIInvenKind _kind, int _slotnum, Item _iteminfo)
    {
        if (InventoryUIDic.ContainsKey(_kind)) //�ش� ������ â�� �����Ѵٸ�
        {
            if (InventoryUIDic[_kind].IsOpen == false)//���� â�� ��Ȱ��ȭ �Ǿ��ִٸ� �׳� return
            {
                return;
            }

            //â�� Ȱ��ȭ �Ǿ�����
            //�ش� slot�� �׷���.

            InventoryUIDic[_kind].DrawSlot(_slotnum, _iteminfo);
        }
    }

    //������ �巡��ǥ�� 2�� �ڷ�ƾ���� Ȥ�� ������Ʈ ���������� TEmpItemUI�� �̵���Ű�� �۾��� ��.
    //������ �巡��ǥ�� 3�� TempItemUI �� ��ġ�� ����

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
