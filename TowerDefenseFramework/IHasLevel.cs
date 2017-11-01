using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    interface IHasLevel
    {
        int getLevel();
        void incrementLevel(int amount = 1);
        void decrementLevel(int amount = 1);
    }
}
