using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    enum Rarity { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY, UNIQUE }
    interface IHasRarity
    {
        Rarity getRarity();
        void increaseRarity();
        void decreaseRarity();
    }
}
