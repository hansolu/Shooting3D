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
        Player,//플레이어
        Storage, //보관함
        Store, //상점
    }
    public enum ItemKind
    { 
        Food = 0, //먹는 종류 음식, 포션
        Armor, //입는 종류 갑옷류..
        Weapon, //무기 종류
        
        Bag, 

        Material,

        End
    }

    public enum FoodKind //
    {
        Bread = 1, //
        Potion = 2, //작동이 다름..
    }
    public enum WeaponKind //
    {
        Sword = 1,
    }
}
