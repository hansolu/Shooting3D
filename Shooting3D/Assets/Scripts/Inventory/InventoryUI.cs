using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour //
{
    public bool IsOpen = false;

    //public CTEnum.UIInvenKind Invenkind;

    //����
    //List<SlotUI> slotlist.......
    List<ItemUI> itemList = new List<ItemUI>(); //����+������ �׷����� ����

    public int InventoryIndex { get; private set; } = 0; //    
    public int widthCount = 0;
    public int heightCount = 0;

    //�׷�����..

    public void DrawSlot(int slotnum, Item iteminfo)
    { 
        
    }
}
