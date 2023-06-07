using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeName
{ 
    ������1,
    ������2,
    ������3,
    End
}

public enum MaterialName
{ 
    ���1 = 20,
    ���2 = 25,
    ���3 = 30,

    End
}

public struct MaterialCombo
{
    public MaterialName mat;
    public int count;

    public MaterialCombo(MaterialName mat, int count)
    {
        this.mat = mat;
        this.count = count;
    }
}

public struct MaterialList
{
    public List<MaterialName> mat ;
    public List<int> count;       
}

public class RecipeScript : MonoBehaviour
{            
    //��ųʸ��� ���
    //��ᰡ ������� ���θ� �˻��� ��� �ϰ� �� ���̳Ŀ� ���� �� ������ �̷��� ������ ����ü�� �������� �ٲ��..

    Dictionary<RecipeName, Dictionary<MaterialName/*int ������. �� �������� ���� ��ġ�� �ʴ� ������ int Index �� ������ �Ѵٸ�. */, int>> RecipeDic 
        = new Dictionary<RecipeName, Dictionary<MaterialName, int>>()
    {
        { RecipeName.������1, new Dictionary<MaterialName, int>(){ { MaterialName.���1, 10}, { MaterialName.���2, 1 } } },
        { RecipeName.������2, new Dictionary<MaterialName, int>(){ { MaterialName.���2, 3}, { MaterialName.���3, 4 } } },
        { RecipeName.������3, new Dictionary<MaterialName, int>(){ { MaterialName.���1, 1}, { MaterialName.���3, 1 } } }
    };

    Dictionary<RecipeName, int> RecipeItemDic = new Dictionary<RecipeName, int>() { { RecipeName.������1 , 13}, { RecipeName.������2, 22 }, { RecipeName.������3, 33 } };

    public bool IsMaterialEnough(RecipeName _recipe, /*Inventory _inven*/int inventoryNum) //�÷��̾��� �κ��丮 ��ü�� �ѱ�
    {
        Inventory _inven = InvenManager.Instance.GetInven(inventoryNum);
        int count = 0;
        
        if (RecipeDic.ContainsKey(_recipe))
        {
            foreach (var item in RecipeDic[_recipe]) //foreach������ ��.. ����ü�� �� ��������
            {
                count = _inven.GetIsAbleCount((int)item.Key); //�κ��� ���� ��� ���� �̻����� �����ϰ� �ִ��� �Ͽ��� üũ�ϴ� �Լ� 
                //GetIsAbleCount �Լ��� ������ �ε����� �˻������� �����ϴ� ��� ���� ��ȯ
                if (count < item.Value) //�����ǿ� �ʿ��� ������ŭ �ִ���. ���ٸ�
                {
                    return false; 
                }                
            }

            return true;
        }
        else
        return false; 
    }
    //���� ���� ���� �Լ��� �߰��ؾ���.
    public void MakeRecipeItem(RecipeName _recipe, /*Inventory _inven*/int inventoryNum)
    {
        Inventory _inven = InvenManager.Instance.GetInven(inventoryNum);
        if (RecipeDic.ContainsKey(_recipe))
        {
            foreach (var item in RecipeDic[_recipe]) //foreach������ ��.. ����ü�� �� ��������
            {
                _inven.SubSimple((int)item.Key, item.Value); //�κ��� ���� ��� ���� �̻����� �����ϰ� �ִ��� �Ͽ��� üũ�ϴ� �Լ�                 
            }

            //������ �Ŵ����� �ִٸ� ������ ��������...

            //�÷��̾� �κ��� ���� �־���? Ȥ�� ���
            _inven.AddSimple( 
            ResourceManager.Instance.CreateItem(RecipeItemDic[_recipe])
            );
        }
    }

    //======================================

    //����ü�ǰ��    
    Dictionary<RecipeName, List< MaterialCombo>> RecipeDic2 = new Dictionary<RecipeName, List<MaterialCombo>>()
    {
        { RecipeName.������1, new List<MaterialCombo>(){  new MaterialCombo(MaterialName.���1, 1), new MaterialCombo(MaterialName.���2, 2) } },
        { RecipeName.������2, new List<MaterialCombo>(){  new MaterialCombo(MaterialName.���2, 1), new MaterialCombo(MaterialName.���3, 2) } },

    };



    Dictionary<RecipeName, MaterialList> RecipeDic3 = new Dictionary<RecipeName, MaterialList>();

    void Awake()
    {
        MaterialList matlist = new MaterialList();
        matlist.mat = new List<MaterialName>();
        matlist.count = new List<int>();
        matlist.mat.Add(MaterialName.���1);
        matlist.count.Add(1);

        matlist.mat.Add(MaterialName.���2);
        matlist.count.Add(2);

        RecipeDic3.Add(RecipeName.������1, matlist);

        matlist = new MaterialList();
        matlist.mat = new List<MaterialName>();
        matlist.count = new List<int>();
        matlist.mat.Add(MaterialName.���2);
        matlist.count.Add(1);

        matlist.mat.Add(MaterialName.���3);
        matlist.count.Add(2);

        RecipeDic3.Add(RecipeName.������2, matlist);
    }    
}
