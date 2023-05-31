using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour //
{
    public bool IsOpen = false;

    //public CTEnum.UIInvenKind Invenkind;

    //슬롯
    //List<SlotUI> slotlist.......
    List<ItemUI> itemList = new List<ItemUI>(); //슬롯+아이템 그려내는 뭔가

    public int InventoryIndex { get; private set; } = 0; //    
    public int widthCount = 0;
    public int heightCount = 0;

    //그려내기..

    public void DrawSlot(int slotnum, Item iteminfo)
    { 
        
    }
}
