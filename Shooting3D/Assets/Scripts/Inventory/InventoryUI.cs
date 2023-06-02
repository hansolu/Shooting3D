using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour //
{
    public bool IsOpen = false;

    public CTEnum.UIInvenKind Invenkind;

    //슬롯
    List<SlotUI> SlotList = new List<SlotUI>();

    public int InventoryIndex { get; private set; } = 0; //    
    public int widthCount = 5;

    GridLayoutGroup grid;
    //public int heightCount = 0;

    //그려내기..
    public void Init(int _slotCount, int _inventorynum)
    {
        if (grid == null)
        {
            grid = GetComponent<GridLayoutGroup>();
        }
        grid.constraintCount = widthCount;

        GameObject tempobj;
        //원래 존재하던 슬롯의 개수가 지금 활성화되어야할 슬롯 보다 개수가 적을때 
        if (SlotList.Count < _slotCount)
        {
            int createslotnum = _slotCount - SlotList.Count;
            for (int i = 0; i < createslotnum; i++)
            {
                tempobj = Instantiate(UIManager.Instance.SlotPrefab, this.transform);
                SlotList.Add(tempobj.GetComponent<SlotUI>());
            }

            for (int i = 0; i < _slotCount; i++)
            {
                SlotList[i].gameObject.SetActive(true); //이것만 하면 슬롯프리팹 그냥 활성화. 내용이 안채워져있음.
                SlotList[i].Init(Invenkind, _inventorynum, i);
            }
        }
        else if (SlotList.Count > _slotCount)
        {
            for (int i = 0; i < SlotList.Count; i++)
            {
                if (i < _slotCount)
                {
                    SlotList[i].gameObject.SetActive(true);
                    SlotList[i].Init(Invenkind, _inventorynum, i);
                }
                else
                {
                    SlotList[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < SlotList.Count; i++)
            {
                SlotList[i].gameObject.SetActive(true);
                SlotList[i].Init(Invenkind, _inventorynum, i);
            }
        }
    }

    //슬롯 하나하나가 바뀌었을때 씀
    public void DrawSlot(int _slotnum, Item _iteminfo)
    {
        if (SlotList.Count < _slotnum)
        {
            Debug.LogError(SlotList.Count + "슬롯 칸이 매개변수의 슬롯 번호보다 적음 : " + _slotnum);
        }
        else
        {
            //Debug.Log("인벤토리ui의 DrawSlot 그려내기" + _slotnum);            
                    
            SlotList[_slotnum].SetItemDraw(_iteminfo.Count > 0? true: false,
                _iteminfo.Index < 0 ? null : ResourceManager.Instance.ItemSprites[_iteminfo.Index],
                _iteminfo.Count.ToString());
        }
    }
}
