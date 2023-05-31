using System.Collections;
using System.Collections.Generic;
using Singleton;

public class InvenManager : Singleton<InvenManager> //
{    
    public static int LastInventoryIdx = 0; //�κ��丮 ���� �ε��� �ο� �ϱ� ����.
    Dictionary<int, Inventory> AllInventoryDic = new Dictionary<int, Inventory>(); //��� �κ��丮 ����.
    
    //�κ��丮 ���� 
    
    public void CreateInven(CTEnum.UIInvenKind _kind, int invencount) //�κ�ĭ ���� �������ֱ�
    {
        LastInventoryIdx++;
        AllInventoryDic.Add(LastInventoryIdx, new Inventory());
        AllInventoryDic[LastInventoryIdx].Init(_kind, invencount, LastInventoryIdx);
    }

    //�κ����� ��������.
    public Inventory GetInven(int invenidx) //�����κ��丮 ��ȣ�� �κ� ��������
    {
        if (AllInventoryDic.ContainsKey(invenidx))
        {
            return AllInventoryDic[invenidx];
        }
        else
        {
            throw new System.Exception($"{invenidx}�� ���� �κ���ȣ");
        }
    }
    
    //�κ��丮 Ȱ��ȭ Ű ������...
    public void SetUIInventoryOpen(int invenidx) //�κ��丮 �ε����� �Ű������� �Լ� �ѹ� �ݸ��ϸ� �ϴ� �� �κ��丮 uiȰ��ȭ ������.
    {
        Item tempItem;
        if (AllInventoryDic.ContainsKey(invenidx))
        {
            UIManager.Instance.ActivateInvenUI(AllInventoryDic[invenidx].InvenKind);

            for (int i = 0; i < AllInventoryDic[invenidx].InvenCount; i++)
            {
                tempItem = AllInventoryDic[invenidx].GetItemInfo(i);
                UIManager.Instance.DrawSlot(AllInventoryDic[invenidx].InvenKind, i,
                    tempItem); //���� �ϳ��ϳ� �׷��� ��.
            }            
        }
    }
    public void SetUIDrawSlot() //�������� �ٲ�� ������Ʈ ��
    {

    }
}
