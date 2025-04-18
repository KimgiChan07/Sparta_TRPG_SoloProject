using Sparta_TRPG_SoloProject.Enums;
using Sparta_TRPG_SoloProject.PlayerInfor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TRPG_SoloProject.Dungeon
{
    public class Roosted
    {
        private int heal = 20;
        public void Roost(P_Info p_Info)
        {
            Console.WriteLine(" ");

            Thread.Sleep(2000);

            if (HealingSucceed())
            {
                int getHp = Convert.ToInt32(p_Info.playerStats[PlayerStats.hp]);
                if (getHp < 100)
                {
                    int setHp = getHp + heal;
                    p_Info.playerStats[PlayerStats.hp] = setHp;

                    Console.WriteLine("집밥을 먹었습니다.");
                    Console.WriteLine($"충분한 휴식을 취했습니다.  Hp +{heal}");
                    Console.WriteLine($"현재체력: {setHp}");
                }
                else if (getHp >= 100)
                {
                    Console.WriteLine("이미 풀컨디션이다.");
                }
            }
            else if (!HealingSucceed())
            {
                Console.WriteLine("중간에 남동생이 난입해 밥상을 엎었습니다!");
                Console.WriteLine("휴식에 실패하였습니다..");
            }

            Thread.Sleep(3000);
        }

        private bool HealingSucceed()
        {
            Random random = new Random();
            if (random.Next(0, 10) > 4)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
