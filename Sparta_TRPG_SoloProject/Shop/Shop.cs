using Sparta_TRPG_SoloProject.Inventory;
using Sparta_TRPG_SoloProject.MainText;
using Sparta_TRPG_SoloProject.PlayerInfor;
using Sparta_TRPG_SoloProject.Enums;
using Sparta_TRPG_SoloProject.TextInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TRPG_SoloProject.Shop
{
    public class ShopSystem
    {
        private Dictionary<int, Item> itemData;
        private _Text text = new _Text();
        private _TextInput textInput = new _TextInput();

        public ShopSystem(_Text _text)
        {
            itemData = Item.itemData;
            text = _text;
        }
        public void OpenShop(P_Info p_Info, InventorySystem inventory)
        {
            while (true)
            {
                text.ShopItemListPrint(itemData, p_Info);
                int input = textInput.InputValue();
                if (input == 0)
                {
                    break;
                }
                BuyItem(input, p_Info, inventory);
                Thread.Sleep(1000);
            }
        }
        public void BuyItem(int itemCode, P_Info p_Info, InventorySystem inventory)
        {
            if (!itemData.TryGetValue(itemCode, out Item item))
            {
                Console.WriteLine("아이템이 존재하지 않습니다.");
                return;
            }

            int currentGold = Convert.ToInt32(p_Info.playerStats[PlayerStats.gold]);

            if (currentGold < item.sellGold)
            {
                Console.WriteLine("소지 금액이 부족합니다.");
                return;
            }

            if (inventory.HasItemCode(itemCode))
            {
                Console.WriteLine("이미 보유중입니다.");
                return;
            }

            p_Info.playerStats[PlayerStats.gold] = currentGold - item.sellGold;

            inventory.AddBuyItem(item.itemCode);

            Console.WriteLine($"{item.name}을 구매하였습니다.");
        }
    }
}
