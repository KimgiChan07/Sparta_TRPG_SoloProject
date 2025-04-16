using Sparta_TRPG_SoloProject.PlayerInfor;
using Sparta_TRPG_SoloProject.MainText;
using Sparta_TRPG_SoloProject.TextInput;
using System;
using System.Collections.Generic;
using Sparta_TRPG_SoloProject.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_TRPG_SoloProject
{
    internal class GameManager
    {
        P_Info p_Info = new P_Info();
        _Text text = new _Text();
        _TextInput textInput = new _TextInput();
        Menu gameStats = new Menu();
        public void Init()
        {
            p_Info.Init();
            text.SetPlayerInfo(p_Info);
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
                            0 => Menu.Main,
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
                            else
                            {
                                Console.Clear();
                                Console.Write("잘못된 입력입니다.");
                                Thread.Sleep(1000);

                            }
                        }
                        break;
                    case Menu.Shop:
                        Console.Clear();
                        Console.WriteLine("아직 미구현_0을 입력해 나가라");
                        Console.Write(">>");
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
                            0 => Menu.Main,
                            _ => Menu.Error
                        };
                        break;
                }
            }
        }
    }
}
