using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeName
{ 
    레시피1,
    레시피2,
    레시피3,
    End
}

public enum MaterialName
{ 
    재료1 = 20,
    재료2 = 25,
    재료3 = 30,

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
    //딕셔너리의 경우
    //재료가 충분한지 여부를 검색을 어디서 하게 할 것이냐에 따라 이 구조도 이렇게 쓰던지 구조체로 쓰던지로 바뀔듯..

    Dictionary<RecipeName, Dictionary<MaterialName/*int 여도됨. 내 아이템이 순수 겹치지 않는 고유한 int Index 로 관리를 한다면. */, int>> RecipeDic 
        = new Dictionary<RecipeName, Dictionary<MaterialName, int>>()
    {
        { RecipeName.레시피1, new Dictionary<MaterialName, int>(){ { MaterialName.재료1, 10}, { MaterialName.재료2, 1 } } },
        { RecipeName.레시피2, new Dictionary<MaterialName, int>(){ { MaterialName.재료2, 3}, { MaterialName.재료3, 4 } } },
        { RecipeName.레시피3, new Dictionary<MaterialName, int>(){ { MaterialName.재료1, 1}, { MaterialName.재료3, 1 } } }
    };

    Dictionary<RecipeName, int> RecipeItemDic = new Dictionary<RecipeName, int>() { { RecipeName.레시피1 , 13}, { RecipeName.레시피2, 22 }, { RecipeName.레시피3, 33 } };

    public bool IsMaterialEnough(RecipeName _recipe, /*Inventory _inven*/int inventoryNum) //플레이어의 인벤토리 자체를 넘김
    {
        Inventory _inven = InvenManager.Instance.GetInven(inventoryNum);
        int count = 0;
        
        if (RecipeDic.ContainsKey(_recipe))
        {
            foreach (var item in RecipeDic[_recipe]) //foreach때문에 좀.. 구조체가 더 나을지도
            {
                count = _inven.GetIsAbleCount((int)item.Key); //인벤에 내가 재료 개수 이상으로 소유하고 있는지 하여간 체크하는 함수 
                //GetIsAbleCount 함수는 아이템 인덱스로 검색했을때 존재하는 모든 개수 반환
                if (count < item.Value) //레시피에 필요한 개수만큼 있는지. 없다면
                {
                    return false; 
                }                
            }

            return true;
        }
        else
        return false; 
    }
    //실제 개수 빼는 함수도 추가해야함.
    public void MakeRecipeItem(RecipeName _recipe, /*Inventory _inven*/int inventoryNum)
    {
        Inventory _inven = InvenManager.Instance.GetInven(inventoryNum);
        if (RecipeDic.ContainsKey(_recipe))
        {
            foreach (var item in RecipeDic[_recipe]) //foreach때문에 좀.. 구조체가 더 나을지도
            {
                _inven.SubSimple((int)item.Key, item.Value); //인벤에 내가 재료 개수 이상으로 소유하고 있는지 하여간 체크하는 함수                 
            }

            //아이템 매니저가 있다면 아이템 생성해줘...

            //플레이어 인벤에 직접 넣어줌? 혹은 드랍
            _inven.AddSimple( 
            ResourceManager.Instance.CreateItem(RecipeItemDic[_recipe])
            );
        }
    }

    //======================================

    //구조체의경우    
    Dictionary<RecipeName, List< MaterialCombo>> RecipeDic2 = new Dictionary<RecipeName, List<MaterialCombo>>()
    {
        { RecipeName.레시피1, new List<MaterialCombo>(){  new MaterialCombo(MaterialName.재료1, 1), new MaterialCombo(MaterialName.재료2, 2) } },
        { RecipeName.레시피2, new List<MaterialCombo>(){  new MaterialCombo(MaterialName.재료2, 1), new MaterialCombo(MaterialName.재료3, 2) } },

    };



    Dictionary<RecipeName, MaterialList> RecipeDic3 = new Dictionary<RecipeName, MaterialList>();

    void Awake()
    {
        MaterialList matlist = new MaterialList();
        matlist.mat = new List<MaterialName>();
        matlist.count = new List<int>();
        matlist.mat.Add(MaterialName.재료1);
        matlist.count.Add(1);

        matlist.mat.Add(MaterialName.재료2);
        matlist.count.Add(2);

        RecipeDic3.Add(RecipeName.레시피1, matlist);

        matlist = new MaterialList();
        matlist.mat = new List<MaterialName>();
        matlist.count = new List<int>();
        matlist.mat.Add(MaterialName.재료2);
        matlist.count.Add(1);

        matlist.mat.Add(MaterialName.재료3);
        matlist.count.Add(2);

        RecipeDic3.Add(RecipeName.레시피2, matlist);
    }    
}
