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

namespace Sparta_TRPG_SoloProject
{
    internal class GameManager
    {
        P_Info p_Info = new P_Info(); 

        InventorySystem inventory = new InventorySystem(Item.itemData);


        _Text text = new _Text();
        ShopSystem shop;
        _TextInput textInput = new _TextInput();
        
        
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
                        sb.AppendLine();
                        sb.AppendLine();
                        sb.AppendLine();
                        sb.AppendLine("[보유아이템 목록]");
                        sb.AppendLine();
                        sb.AppendLine("0. 나가기");
                        text.HasItemText(sb);
                        
                        Console.WriteLine(sb.ToString());

                        Console.WriteLine("\n장착할 아이템의 코드를 입력해주세요");
                        Console.Write(">>");
                        
                        int eqipCoode = textInput.InputValue();
                        if(eqipCoode == 0)
                        {
                            gameStats = Menu.Inventory;
                            break;
                        }
                        else if (!inventory.HasItemCode(eqipCoode))
                        {

                        }
                        else 
                        {
                            inventory.EquipItem(eqipCoode);
                        }
                        break;

                    case Menu.Shop:
                        Console.Clear();
                        shop.OpenShop(p_Info,inventory);

                        int s_test = textInput.InputValue();
                        if (s_test == 0)
                        {
                            gameStats = Menu.Main;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("잘못된 입력입니다.");
                            Thread.Sleep(1000);
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
                            0 => Menu.Main,
                            _ => Menu.Error
                        } ;
                        break;
                }
            }
        }
    }
}
