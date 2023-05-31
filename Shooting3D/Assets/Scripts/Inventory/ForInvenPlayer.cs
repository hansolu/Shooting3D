using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForInvenPlayer : MonoBehaviour //그냥 어쩄거나 사람..
{
    //Inventory inventory;  //나의 인벤토리.인벤매니저를 만들것이기 때문에 내가 인벤토리를 들고 있을 필요없이 내 고유 인벤토리를 찾아낼 고유 index만 있으면 됨.
    public int InventoryIndex; //
    public void Init()

    {                
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //가방열기
            InvenManager.Instance.SetUIInventoryOpen(InventoryIndex);
        }
    }
}
