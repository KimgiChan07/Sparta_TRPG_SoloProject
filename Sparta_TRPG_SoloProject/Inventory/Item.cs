using Sparta_TRPG_SoloProject.Enums;
using Sparta_TRPG_SoloProject.PlayerInfor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sparta_TRPG_SoloProject.Inventory
{
    public class Item
    {

        public List<Stat> stats;

        public int itemCode;

        public string name;
        public string detail;

        public ItemType itemType;
        public static Dictionary<int, Item> itemData = new Dictionary<int, Item>()
        {
            {1, new Item(1,"찢어진 반팔티",ItemType.Armor,new List<Stat>{(new Stat(ItemStatType.def,1))},"집에서 나오던 길에 넘어져 찢어져버린 반팔티이다.") },
            {2, new Item(2,"집에서 쓰던 삼단봉",ItemType.Weapon,new List<Stat>{(new Stat(ItemStatType.damage,1))},"부모님이 혼자살면 위험하다고 사주신 삼단봉이다.") },
            {3, new Item(3,"후즐근한 민소매",ItemType.Armor,new List<Stat>{(new Stat(ItemStatType.def,3))},"버려진 옷을 주워다 진열해 놓은거 같다.") },
            {4, new Item(4,"나무 몽둥이",ItemType.Weapon,new List<Stat>{(new Stat(ItemStatType.damage,3))}, "누군가 조잡하게 나무를 깎은 모양새다.") },
            {5, new Item(5,"나무 갑옷",ItemType.Armor,new List<Stat>{(new Stat(ItemStatType.def,5))}, "나무 몽둥이 옆에 놓여져 있었다.") },
            {6, new Item(6,"철제 키보드",ItemType.Armor,new List<Stat>{(new Stat(ItemStatType.damage,7))}, "상점 주인이 게임하다 샷건으로 고장난 키보드 같다.") },
            {7, new Item(7,"스티브의 갑옷",ItemType.Armor,new List<Stat>{(new Stat(ItemStatType.def,10))}, "네모난 누군가를 떠올리게하는 갑옷이다.") },
        };

        public Item(int _itemCode, string _name, ItemType _itemType, List<Stat> _stat, string _detail)
        {
            itemCode = _itemCode;
            name = _name;
            itemType = _itemType;
            stats = _stat;
            detail = _detail;
        }
    }

    public class Stat
    {
        public ItemStatType statType;
        public int value;
        public Stat() { }
        public Stat(ItemStatType _statType,int _value)
        {
            statType = _statType;
            value = _value;
        }
    }


}