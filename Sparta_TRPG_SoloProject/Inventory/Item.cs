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
        public int sellGold;

        public string name;
        public string detail;

        public ItemType itemType;
        public static Dictionary<int, Item> itemData = new Dictionary<int, Item>()
        {

            {1, new Item(1, "찢어진 반팔티", ItemType.Armor, new List<Stat>{(new Stat(ItemStatType.def, 1))},"집에서 나오던 길에 넘어져 찢어져버린 반팔티이다.", 200) },
            {2, new Item(2, "길에서 주운 나무막대", ItemType.Weapon, new List<Stat>{(new Stat(ItemStatType.damage, 1))},"어린아이가 전쟁놀이때 사용하던 막대기같다.", 300) },
            {3, new Item(3, "후즐근한 민소매", ItemType.Armor, new List<Stat>{(new Stat(ItemStatType.def, 3))},"버려진 옷을 주워다 진열해 놓은거 같다.", 500) },
            {4, new Item(4, "집에서 쓰던 삼단봉", ItemType.Weapon, new List<Stat>{(new Stat(ItemStatType.damage, 3))},"부모님이 혼자살면 위험하다고 사주신 삼단봉이다.", 600) },
            {5, new Item(5, "나무 갑옷", ItemType.Armor, new List<Stat>{(new Stat(ItemStatType.def, 5))}, "나무 몽둥이 옆에 놓여져 있었다.", 600) },
            {6, new Item(6, "나무 몽둥이", ItemType.Weapon, new List<Stat>{(new Stat(ItemStatType.damage, 5))}, "누군가 조잡하게 나무를 깎은 모양새다.", 700) },
            {7, new Item(7, "철제 키보드", ItemType.Armor, new List<Stat>{(new Stat(ItemStatType.damage, 7))}, "상점 주인이 게임하다 샷건으로 고장난 키보드 같다.", 1200) },
            {8, new Item(8, "스티브의 갑옷", ItemType.Armor, new List<Stat>{(new Stat(ItemStatType.def, 10))}, "네모난 누군가를 떠올리게하는 갑옷이다.", 1500) },

        };

        public Item(int _itemCode, string _name, ItemType _itemType, List<Stat> _stat, string _detail, int _sellGold)
        {
            itemCode = _itemCode;
            name = _name;
            itemType = _itemType;
            stats = _stat;
            detail = _detail;
            sellGold = _sellGold;
        }
    }

    public class Stat
    {
        public ItemStatType statType;
        public int value;
        public Stat() { }
        public Stat(ItemStatType _statType, int _value)
        {
            statType = _statType;
            value = _value;
        }
    }

}