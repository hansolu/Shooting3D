using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour //
{
    public bool IsOpen = false;

    public CTEnum.UIInvenKind Invenkind;

    //����
    List<SlotUI> SlotList = new List<SlotUI>();

    public int InventoryIndex { get; private set; } = 0; //    
    public int widthCount = 5;

    GridLayoutGroup grid;
    //public int heightCount = 0;

    //�׷�����..
    public void Init(int _slotCount, int _inventorynum)
    {
        if (grid == null)
        {
            grid = GetComponent<GridLayoutGroup>();
        }
        grid.constraintCount = widthCount;

        GameObject tempobj;
        //���� �����ϴ� ������ ������ ���� Ȱ��ȭ�Ǿ���� ���� ���� ������ ������ 
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
                SlotList[i].gameObject.SetActive(true); //�̰͸� �ϸ� ���������� �׳� Ȱ��ȭ. ������ ��ä��������.
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

    //���� �ϳ��ϳ��� �ٲ������ ��
    public void DrawSlot(int _slotnum, Item _iteminfo)
    {
        if (SlotList.Count < _slotnum)
        {
            Debug.LogError(SlotList.Count + "���� ĭ�� �Ű������� ���� ��ȣ���� ���� : " + _slotnum);
        }
        else
        {
            //Debug.Log("�κ��丮ui�� DrawSlot �׷�����" + _slotnum);            
                    
            SlotList[_slotnum].SetItemDraw(_iteminfo.Count > 0? true: false,
                _iteminfo.Index < 0 ? null : ResourceManager.Instance.ItemSprites[_iteminfo.Index],
                _iteminfo.Count.ToString());
        }
    }
}
