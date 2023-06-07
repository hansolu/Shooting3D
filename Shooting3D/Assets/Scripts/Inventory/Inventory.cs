using System.Collections;
using System.Collections.Generic;

public class Inventory //�κ��丮 �Ŵ����� ���� �ε� / �� ��ü�� �޾Ƴ���.. 
{

    /*
     * �� �κ��丮 ��ũ��Ʈ��
     * ����̰�, �������̰� �������
     * ������ ��ųʸ�(ItemDic)�� ��� �ִ�, �����ͷν��� �κ��丮
     * �κ��丮�� ���� �� �˻��� Index�� �����ϸ�
     * �κ��丮�� ��ü ũ��� InvenCount�� �� �� ����.
     * ���ϱ�, ���� �⺻ ��� �� Get~���� ������ �������� ����.
     */

    public CTEnum.UIInvenKind InvenKind { get; private set; } //����� �κ����� ���������� ����.. 
    public int Index { get; private set; } = 0; //�κ��丮�� ������ȣ //�κ��丮 ������ȣ �����ϴ� �κ��� ��� �����־���Ұ�.
    public int InvenCount { get; private set; } = 0; //�κ��� ���� �ִ�ĭ��
    //public int InvenCount => ItemDic.Count;

    ////���� ������ ĭ�� �ݵ�� ���� ���� �Ͱ�, ������� ���ϰ� ���� �ϰ�ʹ�. //��������
    //Item[] ItemArr;//= new Item[10];  // 0 0 0 0 0 
    //                                  // 0 0 0 0 0

    ////�ڵ����� �� �κ��丮 ������ ����
    List<Item> ItemList = new List<Item>(); //Item �� count�� 0�̵����� ������ �ʴ� ��찡 �ƴ϶��
    ////�ظ��ϸ� ������� ���� �� ���־ //��ư count�� ���� �����Ⱑ ����
    
    //�ڵ����� ���� �������� �迭ó�� �����ϰ� ����. //�ٵ� ��� ���� �ȵ�....����
    Dictionary<int, Item> ItemDic = new Dictionary<int, Item>(); // 


    //���� ������ �������� Index������ ���� ���� ����...


    public void Init(CTEnum.UIInvenKind _kind, int invencount, int Index=-1) //ó�� ����
    {
        if (Index >= 0)
        {
            this.Index = Index;
        }
        InvenCount = invencount;
        for (int i = 0; i < InvenCount; i++)
        {
            ItemDic.Add(i, /*null*/new Item()); //�������� ������ ����... 
            //���� ������ �÷��� ä���...
        }
    }

    //public void InitLoad() //�ҷ����� ���� �ϰԵǸ� ä�����..
    //{
    //}

    public List<Item> GetAllItemInfo()
    {
        List<Item> returnList = new List<Item>();
        for (int i = 0; i < InvenCount; i++)
        {
            returnList.Add(ItemDic[i]);
        }
        return returnList;
    }

    public Item GetItemInfo(int slotnum)
    {
        return ItemDic[slotnum];
    }

    //������ ���ϱ� //�׳� �ݴ� ��� / �巡�׷� ���ϴ� ���.. (���� ���ϴ� ���) 
    //������ ���� //���Ű��� �ڵ����� ���� ���... Ŭ���ؼ� �ű���� ������ ���.
    //�ڵ�����...

    public void AddSimple(Item _item) //���� ��� ���� �̷��� �ʿ���� �׳� �ݱ�
    {
        //������ ���� ������ ������ �� ĭ �� ä��� ������ ���ϱ�..        
        for (int i = 0; i < InvenCount; i++)
        {
            if (ItemDic[i].Index == _item.Index) //���� ������
            {
                if (ItemDic[i].AbleCount >= _item.Count) //�״�� ������ ����.
                {
                    _item.SetCount(ItemDic[i].AddCount(_item.Count));                    
                    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // �κ��丮 ������ȣ, ���Թ�ȣ, ����������..
                    break;
                }
                //else //���Ƽ� �������� �ٸ�ĭ�� ���� �־����.
                //{
                //    _item.SetCount( ItemDic[i].AddCount(_item.Count));
                //    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // �κ��丮 ������ȣ, ���Թ�ȣ, ����������..
                //}                
            }            
        }

        if (_item.Count > 0) //������ ������ �ִ�
        {
            for (int i = 0; i < InvenCount; i++)
            {
                if (ItemDic[i].Count == 0) //����ִ� ĭ.
                {
                    ItemDic[i].SetItem(_item);
                    _item.SetCount(0);

                    UIManager.Instance.DrawSlot(InvenKind, i, ItemDic[i]); // �κ��丮 ������ȣ, ���Թ�ȣ, ����������..
                    break;
                }
            }

            if (_item.Count > 0)
            {
                //�ٴڿ� ������...
                //���� ������ �Ŵ����� �־ ����������� ���� �����ϰ� �����ϰ� �Ѵٸ� ������ ��û =>�̰� ����.
                //�װ� �ƴ϶�� �������̺�� ��ӹް� Instantiate�ؼ� ������ ���� �� ��� �ϱ�...
            }
        }
        
        //UIManager.Instance.Redraw(); //��ư �� �κ� �ٲ�����ϱ� �ٽ� �� �׷���.
    }

    public Item AddSlot(int slotnum, Item _item)//Ư�� ���Կ��ٰ� ���� ���ϴ� ������ ����.
    {        
        if (ItemDic[slotnum].Index == _item.Index) //���� ������
        {
            //�Ǻ��ؼ� �׳� ������
            int overnum = ItemDic[slotnum].AddCount(_item.Count); //���� ������ Max�� �Ѱ����� overnum�� 0���� Ŭ��.
            _item.SetCount(overnum);
        }        
        else  //�ε����� �ٸ�
        {
            if (ItemDic[slotnum].Count == 0 ) //�������
            {
                ItemDic[slotnum].SetItem(_item); //��ĭ�� ������ �����ؼ� �ֱ�
                _item.SetCount(0); //�� �������� ����.
            }
            else //�ƿ� �ٸ� ������ ������.
            {
                //�������ֱ�...
                Item tempItem = new Item();
                tempItem.SetItem( ItemDic[slotnum]); //
                ItemDic[slotnum].SetItem(_item); //���� �Ű������� ���� �������� ������ ��ųʸ��� ä����
                _item.SetItem(tempItem); //���ҿϷ�
            }
        }

        //if (_item.Count > 0) //���ϰ� ���ߴµ� �տ� ���� ���� ��� ����
        //{            
        //}
        return _item; //�̰Ŵ� �޴� �ʿ��� ���� ����ִ��� �ƴ��� �Ǻ��ϰ� �սô�.
    }

    //public bool IsExist(int index, int count)
    //{ 
    //    //�� �κ� �˻��ؼ�
    //    //�ش� index �������� �ִ���, count ������ŭ �ִ°� �´���

    //    //�� ���� ����
    //}

    public int GetIsAbleCount(int index)
    {
        int isablecount = 0;
        for (int i = 0; i < InvenCount; i++)
        {
            if (ItemDic[i].Index == index)
            {
                isablecount += ItemDic[i].Count;
            }
        }
        return isablecount;
    }
    public bool SubSimple(int itemIndex, int count ) //���� ���� �������� �ŷ�.. ���� ���� �������� Ư�� �����۰� Ư�� �����Ǻ�
    {        
        int isablecount = GetIsAbleCount(itemIndex);        
        
        //���� ������ �� �˻�..
        if (isablecount < count)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < InvenCount; i++)
            {
                if (ItemDic[i].Index == itemIndex)
                {
                    count = ItemDic[i].SubCount(count);
                    if (count == 0)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }

    public Item SubSlot(int slotnum) //Ư�� ����°�� ����.
    {        
        Item temp = new Item();
        temp.SetItem(ItemDic[slotnum]);
        ItemDic[slotnum].Clear();
        return temp;
    }
}
