using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparta_TRPG_SoloProject.Enums;
using System.Threading.Tasks;
using Sparta_TRPG_SoloProject.MainText;
using Sparta_TRPG_SoloProject.TextInput;

namespace Sparta_TRPG_SoloProject.PlayerInfor
{
    internal class P_Info
    {
        public Dictionary<PlayerInfo, object>? playerStats;
        public void Init()
        {
            playerStats = new Dictionary<PlayerInfo, object>
            {
                { PlayerInfo.Lv,1 },
                { PlayerInfo.name,"SprtaMan" },
                { PlayerInfo.hp,100 },
                { PlayerInfo.damage,10 },
                { PlayerInfo.def,5 },
                { PlayerInfo.gold,1500 }
            };
        }

    }
}
