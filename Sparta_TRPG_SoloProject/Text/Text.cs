using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparta_TRPG_SoloProject.PlayerInfor;
using Sparta_TRPG_SoloProject.TextInput;
using System.Threading.Tasks;
using Sparta_TRPG_SoloProject.Inventory;



namespace Sparta_TRPG_SoloProject.MainText
{
    class _Text
    {
        private InventorySystem inventorySystem;
        private P_Info playerInfor = new P_Info();
        _TextInput textInput = new _TextInput();
        public void MainTextPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[스파르타 마을에 오신 여러분 환영합니다!]");
            sb.AppendLine();
            sb.Append("[이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.]");
            sb.AppendLine();
            sb.Append("\n1. 내정보\n2. 인벤토리\n3. 상점");
            sb.AppendLine();
            sb.Append("\n원하시는 행동을 입력해주세요.");
            sb.AppendLine();
            sb.Append("\n>>");
            Console.Write(sb.ToString());
        }
        public void SetPlayerInfo(P_Info info)
        {
            playerInfor = info;
        }
        public void PlayerInfoTextPrint()
        {

            var statDisPlay = inventorySystem.EquippedStatDisPlay();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("캐릭터의 정보가 표시됩니다");
            sb.AppendLine();
            sb.AppendLine();

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
                else if(statDisPlay.TryGetValue(stat.Key, out int statValue) && statValue != 0)
                {
                   sb.AppendLine($"{stat.Key}: {stat.Value} (+{statValue})");
                }
                else
                {
                    sb.AppendLine($"[{stat.Key}]: {stat.Value}");
                }
            }
            sb.AppendLine("\n0. 나가기");

            sb.Append("\n>>");

            Console.Write(sb.ToString());
        }


        public void SetInventory(InventorySystem _inventory)
        {
            inventorySystem = _inventory; 
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

            HasItemText(sb);

            sb.AppendLine();
            sb.Append("1. 장착관리\n0. 나가기");
            sb.AppendLine();
            sb.Append("\n원하시는 행동을 입력해주세요.");
            sb.AppendLine();
            sb.Append("\n>>");
            Console.Write(sb.ToString());
        }
        public void HasItemText(StringBuilder sb)
        {
            if (inventorySystem != null)
            {
                const int namePadding = 30;
                foreach (var item in inventorySystem.GetOwnedItems())
                {
                    bool isEquipped = (inventorySystem.equippedWeapon==item||inventorySystem.equippedArmor==item);

                    string disPlayText = item.name + (isEquipped ? " [장착]" : "");
                    disPlayText = disPlayText.PadRight(namePadding);

                    sb.AppendLine($"{item.itemCode}. {disPlayText} l {item.detail}");
                }
            }
            else
            {
                sb.AppendLine("※ 인벤토리 데이터가 없습니다.");
            }
        }
        public void EquippedItemTextPrint()
        {
            Console.WriteLine("[장착중인 아이템]");
            if (inventorySystem != null)
            {
                inventorySystem.PrintEquippedItems();
            }
            else
            {
                Console.WriteLine("장착정보 없음");
            }
        }
    }
}
