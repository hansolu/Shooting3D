public class CTEnum
{
    public enum ItemIndex
    { 
        apple,
        armor,
        axe,
        bag,
        belts,
        book
    }
    public enum UIInvenKind
    {
        Player,//�÷��̾�
        Storage, //������
        Store, //����
    }
    public enum ItemKind
    { 
        Food = 0, //�Դ� ���� ����, ����
        Armor, //�Դ� ���� ���ʷ�..
        Weapon, //���� ����
        
        Bag, 

        Material,

        End
    }

    public enum FoodKind //
    {
        Bread = 1, //
        Potion = 2, //�۵��� �ٸ�..
    }
    public enum WeaponKind //
    {
        Sword = 1,
    }
}
