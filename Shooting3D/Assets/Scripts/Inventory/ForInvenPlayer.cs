using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForInvenPlayer : MonoBehaviour //그냥 어쩄거나 사람..
{
    //Inventory inventory;  //나의 인벤토리.인벤매니저를 만들것이기 때문에 내가 인벤토리를 들고 있을 필요없이 내 고유 인벤토리를 찾아낼 고유 index만 있으면 됨.
    public int InventoryIndex; //나의 인벤토리 번호...

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
            //가방열기
        }

        if (Input.GetKeyDown(KeyCode.Space)) //아이템 주웠다고 가정
        {            
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Food, 0), InventoryIndex);
        }

        if (Input.GetKeyDown(KeyCode.Z)) //아이템 주웠다고 가정
        {
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Armor, 1), InventoryIndex);
        }

        if (Input.GetKeyDown(KeyCode.X)) //아이템 주웠다고 가정
        {
            InvenManager.Instance.AddItem(ResourceManager.Instance.CreateItem(CTEnum.ItemKind.Weapon, 2), InventoryIndex);
        }
    }
}
