using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    enum ItemRarity { }
    abstract class Item
    {
        int level;
        ItemRarity rarity;



        abstract void applyEffects(PrimaryObject holder);

        abstract void removeEffects(PrimaryObject holder);
    }
}
