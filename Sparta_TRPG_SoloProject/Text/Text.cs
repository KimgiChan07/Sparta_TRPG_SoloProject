using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparta_TRPG_SoloProject.PlayerInfor;
using Sparta_TRPG_SoloProject.TextInput;
using System.Threading.Tasks;
using Sparta_TRPG_SoloProject.Inventory;
using Sparta_TRPG_SoloProject.Enums;



namespace Sparta_TRPG_SoloProject.MainText
{
    public class _Text
    {
        private InventorySystem inventory;
        private P_Info playerInfor = new P_Info();
        _TextInput textInput = new _TextInput();

        public void SetPlayerInfo(P_Info info)
        {
            playerInfor = info;
        }
        public void SetInventory(InventorySystem _inventory)
        {
            inventory = _inventory;
        }

        public void MainTextPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[스파르타 마을에 오신 여러분 환영합니다!]");
            sb.AppendLine();
            sb.Append("[이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.]");
            sb.AppendLine();
            sb.AppendLine("\n1. 내정보\n2. 인벤토리\n3. 상점");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("원하시는 행동을 입력해주세요.");

            sb.Append("\n>>");
            Console.Write(sb.ToString());
        }

        public void PlayerInfoTextPrint()
        {
            var statDisPlay = inventory.EquippedStatDisPlay();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("캐릭터의 정보가 표시됩니다");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("-----------------------------");

            foreach (var stat in playerInfor.playerStats)
            {
                if (stat.Key == Enums.PlayerStats.gold)
                {
                    sb.AppendLine($"\n[{stat.Key}]: {stat.Value}G");
                    continue;
                }
                else if (stat.Key == Enums.PlayerStats.Lv)
                {
                    sb.AppendLine($"{stat.Key}. {stat.Value}");
                }
                else if (statDisPlay.TryGetValue(stat.Key, out int statValue) && statValue != 0)
                {
                    sb.AppendLine($"{stat.Key}: {stat.Value} (+{statValue})");
                }
                else
                {
                    sb.AppendLine($"[{stat.Key}]: {stat.Value}");
                }
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("-----------------------------");
            sb.AppendLine("[장착아이템]");
            sb.AppendLine();
            if (inventory.equippedWeapon != null)
            {
                var weapon = inventory.equippedWeapon;
                string stats = string.Join(", ", weapon.stats.Select(s => $"+{s.statType} {s.value}"));
                sb.AppendLine($"무기: {weapon.name} ({stats})");
            }
            else
            {
                sb.AppendLine("무기: 미장착");
            }
            if (inventory.equippedArmor != null)
            {
                var armor = inventory.equippedArmor;
                string stats = string.Join(", ", armor.stats.Select(s => $"+{s.statType} {s.value}"));
                sb.AppendLine($"방어구: {armor.name} ({stats})");
            }
            else
            {
                sb.AppendLine("방어구: 미장착");
            }

            sb.AppendLine("-----------------------------");
            sb.AppendLine("\n0. 나가기");
            sb.AppendLine();
            
            sb.Append("원하시는 행동을 입력해주세요.");
            sb.Append("\n>>");
            Console.Write(sb.ToString());
        }

        public void InventoryTextPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<인벤토리>");
            
            sb.AppendLine();
            
            sb.Append("보유 중인 아이템을 관리할 수 있습니다.");
            
            sb.AppendLine();
            sb.AppendLine();
            
            sb.Append("[보유 아이템 목록]");
            
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("-----------------------------");

            HasItemText(sb);
            
            sb.AppendLine("-----------------------------");
            sb.AppendLine();
            sb.AppendLine();
            
            sb.Append("1. 장착관리\n0. 나가기");
            sb.AppendLine();
            sb.AppendLine();
            
            sb.Append("-----------------------------");
            sb.Append("\n원하시는 행동을 입력해주세요.");
            sb.AppendLine();
            sb.Append("\n>>");
            
            Console.Write(sb.ToString());
        }

        public void HasItemText(StringBuilder sb)
        {
            if (inventory != null)
            {
                foreach (var item in inventory.GetOwnedItems())
                {
                    bool isEquipped = (inventory.equippedWeapon == item || inventory.equippedArmor == item);

                    string name = item.name + (isEquipped ? " [장착]" : "");
                    name = SetTextSort(name, 30); // 이름 길이 정렬

                    string statInfo = SetTextSort(string.Join(", ", item.stats.Select(s => $"+{s.statType} {s.value}")), 20); // 스탯 정렬

                    sb.AppendLine($"{item.itemCode}. {name} | {statInfo} | {item.detail}");
                }
            }
            else
            {
                sb.AppendLine("인벤토리 데이터가 없습니다.");
            }
        }

        public void EquippedItemTextPrint()
        {
            Console.WriteLine("[장착중인 아이템]");
            if (inventory != null)
            {
                inventory.PrintEquippedItems();
            }
            else
            {
                Console.WriteLine("장착정보 없음");
            }
        }

        public void PrintShopItemList(Dictionary<int, Item> itemData, P_Info playerInfo)
        {
            int currentGold = Convert.ToInt32(playerInfo.playerStats[PlayerStats.gold]);
            StringBuilder sb = new StringBuilder();
            Console.Clear();
            sb.AppendLine("<상점 목록>");
            sb.AppendLine($"보유 골드: {currentGold} G\n");
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine("구매 가능 아이템:\n");

            const int namePadding = 30;
            const int statPadding = 15;
            const int pricePadding = 10;

            foreach (var pair in itemData)
            {
                Item item = pair.Value;

                string name = SetTextSort(item.name, namePadding);
                string stats = SetTextSort(string.Join(", ", item.stats.Select(s => $"+{s.statType} {s.value}")), statPadding);
                string pricetext = inventory.HasItemCode(item.itemCode) ? $"[보유중]   l {item.detail}" : $"가격: {item.sellGold}G ㅣ {item.detail}";

                string price= SetTextSort(pricetext, pricePadding);

                sb.AppendLine($"{item.itemCode}. {name}l {stats}l {price}");
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("\n0. 나가기");
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine("\n원하시는 행동을 입력해주세요.");
            
            sb.Append(">> ");
            Console.Write(sb.ToString());
        }

        private int GetTextSortLength(string text)
        {
            int len = 0;
            foreach (char c in text)
            {
                len += (c >= 0xAC00 && c <= 0xD7A3) ? 2 : 1;
            }
            return len;
        }

        public string SetTextSort(string text, int targetWidht)
        {
            int len = GetTextSortLength(text);
            int ppading = Math.Max(0, targetWidht - len);
            return text + new string(' ', ppading);
        }
    }
}
