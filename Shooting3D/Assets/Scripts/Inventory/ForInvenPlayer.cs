using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForInvenPlayer : MonoBehaviour //�׳� ��ų� ���..
{
    //Inventory inventory;  //���� �κ��丮.�κ��Ŵ����� ������̱� ������ ���� �κ��丮�� ��� ���� �ʿ���� �� ���� �κ��丮�� ã�Ƴ� ���� index�� ������ ��.
    public int InventoryIndex; //
    public void Init()

    {                
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //���濭��
            InvenManager.Instance.SetUIInventoryOpen(InventoryIndex);
        }
    }
}
