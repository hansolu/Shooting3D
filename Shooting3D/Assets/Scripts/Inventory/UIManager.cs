using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class UIManager : SingletonMono<UIManager>
{  
    //������ �������� �ϳ��� �鱸����.
    Dictionary<CTEnum.UIInvenKind, InventoryUI> InventoryUIDic = new Dictionary<CTEnum.UIInvenKind, InventoryUI>();

    public ItemUI TempItemUI; //����ִ� Ŭ������ �巡������ ������ �׷����� ui

    public GameObject PlayerBagPrefab; //����� �κ��丮 ui������
    public GameObject StoragePrefab; //�������� �κ��丮 ui������

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
   
    public void ActivateInvenUI(CTEnum.UIInvenKind _kind) //�κ��丮 ��ü â�� ������.
    {
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
    public void DrawSlot(CTEnum.UIInvenKind kind, int slotnum, Item iteminfo)
    {
        //���� â�� ��Ȱ��ȭ �Ǿ��ִٸ� �׳� return
        //â�� Ȱ��ȭ �Ǿ��ִٸ�
        //�ش� slot�� �׷���.
        
    }


}
