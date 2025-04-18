using Sparta_TRPG_SoloProject.PlayerInfor;
using Sparta_TRPG_SoloProject.MainText;
using Sparta_TRPG_SoloProject.TextInput;
using System;
using System.Collections.Generic;
using Sparta_TRPG_SoloProject.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_TRPG_SoloProject.Inventory;
using Sparta_TRPG_SoloProject.Shop;
using Sparta_TRPG_SoloProject.Dungeon;

namespace Sparta_TRPG_SoloProject
{
    internal class GameManager
    {
        private P_Info p_Info = new P_Info();
        private InventorySystem inventory = new InventorySystem(Item.itemData);
        private _Text text = new _Text();
        private _TextInput textInput = new _TextInput();
        private ShopSystem shop;

        Menu gameStats = new Menu();
        public void Init()
        {
            p_Info.Init();
            text.SetPlayerInfo(p_Info);
            inventory.SetPlayerInfo(p_Info);
            text.SetInventory(inventory);
            shop = new ShopSystem(text);
        }

        public void TRPG_Main()
        {
            Init();
            while (true)
            {
                switch (gameStats)
                {
                    case Menu.Main:
                        Console.Clear();
                        text.MainTextPrint();
                        int input = textInput.InputValue();
                        gameStats = input switch
                        {
                            1 => Menu.PlayerInfo,
                            2 => Menu.Inventory,
                            3 => Menu.Shop,
                            4 => Menu.Rest,
                            _ => Menu.Error
                        };
                        break;
                    case Menu.PlayerInfo:
                        while (true)
                        {
                            Console.Clear();
                            text.PlayerInfoTextPrint(); // 출력만 담당
                            int p_input = textInput.InputValue();
                            if (p_input == 0)
                            {
                                Console.Clear();
                                gameStats = Menu.Main;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("잘못된 입력입니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    case Menu.Inventory:
                        while (true)
                        {
                            Console.Clear();
                            text.InventoryTextPrint(); // 출력만 담당
                            int p_input = textInput.InputValue();
                            if (p_input == 0)
                            {
                                gameStats = Menu.Main;
                                break;
                            }
                            else if (p_input == 1)
                            {
                                gameStats = Menu.EquipItem;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("잘못된 입력입니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    case Menu.EquipItem:
                        StringBuilder sb = new StringBuilder();
                        Console.Clear();
                        text.EquippedItemTextPrint();
                        sb.AppendLine("0. 나가기");
                        text.HasItemTextPrint(sb);

                        Console.WriteLine(sb.ToString());
                        Console.WriteLine("\n장착할 아이템의 코드를 입력해주세요");
                        Console.Write(">>");

                        int eqipCoode = textInput.InputValue();
                        if (eqipCoode == 0)
                        {
                            gameStats = Menu.Inventory;
                            break;
                        }
                        else if (!inventory.HasItemCode(eqipCoode))
                        {
                            Console.WriteLine("보유하지 않은 아이템입니다.");
                        }
                        else
                        {
                            inventory.EquipItem(eqipCoode);
                        }
                        break;

                    case Menu.Shop:
                        Console.Clear();
                        shop.OpenShop(p_Info, inventory);
                        gameStats = Menu.Main;
                        break;

                    case Menu.Rest:
                        Console.Clear();
                        Console.WriteLine("잠시 부모님집에 왔다. \n집에 아무도 없다...");
                        Console.WriteLine("\n0. 나가기\n1. 냉장고 뒤지기\n\n");
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">>");
                        int r_Input = textInput.InputValue();
                        if (r_Input == 1)
                        {
                            text.HealingTextPrint();
                            gameStats = Menu.Main;

                        }
                        else if (r_Input == 0)
                        {
                            gameStats = Menu.Main;
                        }
                        break;

                    case Menu.Error:
                        Console.Write("[잘못된 입력입니다. 1~3을 입력해주세요.]\n");
                        int errorInput = textInput.InputValue();

                        gameStats = errorInput switch
                        {
                            1 => Menu.PlayerInfo,
                            2 => Menu.Inventory,
                            3 => Menu.Shop,
                            4 => Menu.Rest,
                            0 => Menu.Main,
                            _ => Menu.Error
                        };
                        break;
                }
            }
        }
    }
}
