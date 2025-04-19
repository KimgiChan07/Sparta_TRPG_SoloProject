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
    public  class P_Info
    {
        public Dictionary<PlayerStats, object>? playerStats;
        public void Init()
        {
            playerStats = new Dictionary<PlayerStats, object>
            {
                { PlayerStats.Lv,1 },
                { PlayerStats.name,"SprtaMan" },
                { PlayerStats.hp,100 },
                { PlayerStats.damage,10 },
                { PlayerStats.def,5 },
                { PlayerStats.gold,1500 }
            };
        }
    }
}
