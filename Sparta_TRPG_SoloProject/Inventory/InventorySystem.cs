using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_TRPG_SoloProject.Enums;
using Sparta_TRPG_SoloProject.PlayerInfor;

namespace Sparta_TRPG_SoloProject.Inventory
{
    public class InventorySystem
    {
        private Dictionary<int, Item> itemData;
        private List<int> hasItemCodes;

        private P_Info p_Info;

        public Item equippedWeapon = null;
        public Item equippedArmor = null;


        public InventorySystem(Dictionary<int, Item> _itemData)
        {
            itemData = _itemData;
            hasItemCodes = new List<int>();

            InitDefaultInventory();
        }

        private void InitDefaultInventory()
        {
            hasItemCodes.Add(1);
            hasItemCodes.Add(2);
        }

        public List<Item> GetOwnedItems()
        {
            List<Item> result = new List<Item>();
            foreach (int code in hasItemCodes)
            {
                if (itemData.TryGetValue(code, out Item item))
                    result.Add(item);
            }
            return result;
        }
        public bool HasItemCode(int code)
        {
            return hasItemCodes.Contains(code);
        }

        public void EquipItem(int code)
        {
            if(!itemData.TryGetValue(code,out Item item))
            {
                Console.WriteLine("알맞은 값을 입력해주세요.");
            }

            if(item.itemType==ItemType.Weapon)
            {
                if (equippedWeapon != null && equippedWeapon.itemCode == item.itemCode)
                {
                    equippedWeapon = null;
                }
                else
                {
                    equippedWeapon = item;


                }
            }
            else if(item.itemType==ItemType.Armor)
            {
                if (equippedArmor != null && equippedArmor.itemCode == item.itemCode)
                {
                    equippedArmor = null;
                }
                else
                {
                    equippedArmor = item;

                }
            }
            else
            {
                Console.WriteLine("할당된 값이 없습니다.");
            }
        }

        public void PrintEquippedItems()
        {
            Console.WriteLine($"\n방어구: {(equippedArmor != null ? equippedArmor.name : "없음")}");
            Console.WriteLine($"무기: {(equippedWeapon != null ? equippedWeapon.name : "없음")}");
        }

        public void SetPlayerInfo(P_Info _Info)
        {
            p_Info = _Info;
        }

        private static readonly Dictionary<ItemStatType, PlayerStats> setStat = new()
        {
            { ItemStatType.damage,PlayerStats.damage},
            { ItemStatType.def,PlayerStats.def},

        };
        public Dictionary<PlayerStats, int> EquippedStatDisPlay()
        {
            Dictionary<PlayerStats, int> statDisPlay = new();

            void AddStat(Item item)
            {
                if (item == null) return;

                foreach (var stat in item.stats)
                {
                    if (!setStat.TryGetValue(stat.statType, out var statsKey)) continue;

                    if (statDisPlay.ContainsKey(statsKey))
                    {
                        statDisPlay[statsKey] += stat.value;
                    }else
                        statDisPlay[statsKey] = stat.value;
                }
            }

            AddStat(equippedArmor);
            AddStat(equippedWeapon);

            return statDisPlay;
        }
        public void AddBuyItem(int itemCode)
        {
            if (hasItemCodes.Contains(itemCode)){

                hasItemCodes.Add(itemCode);
            }
        }

    }
}
