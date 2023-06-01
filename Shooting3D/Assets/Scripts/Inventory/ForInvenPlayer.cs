using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForInvenPlayer : MonoBehaviour //�׳� ��ų� ���..
{
    //Inventory inventory;  //���� �κ��丮.�κ��Ŵ����� ������̱� ������ ���� �κ��丮�� ��� ���� �ʿ���� �� ���� �κ��丮�� ã�Ƴ� ���� index�� ������ ��.
    public int InventoryIndex; //���� �κ��丮 ��ȣ...

    bool IsBagOpen = false;

    void Start()
    {
        IsBagOpen = false;
        Init();
    }
    public void Init()
    {
        InventoryIndex = InvenManager.Instance.CreateInven( CTEnum.UIInvenKind.Player, 15);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (IsBagOpen)
            {
                IsBagOpen = false;
                
            }
            else
            {
                IsBagOpen = true;                
            }

            UIManager.Instance.ActivateInvenUI(IsBagOpen, CTEnum.UIInvenKind.Player, InventoryIndex);
            //���濭��
        }

        if (Input.GetKeyDown(KeyCode.Space)) //������ �ֿ��ٰ� ����
        {            
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Food, 0), InventoryIndex);
        }

        if (Input.GetKeyDown(KeyCode.Z)) //������ �ֿ��ٰ� ����
        {
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Armor, 1), InventoryIndex);
        }

        if (Input.GetKeyDown(KeyCode.X)) //������ �ֿ��ٰ� ����
        {
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Weapon, 2), InventoryIndex);
        }
    }
}
