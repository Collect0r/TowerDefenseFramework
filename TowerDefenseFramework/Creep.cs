using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.CustomEventArgs;

namespace TowerDefenseFramework
{
    enum CreepType { }
    enum ArmorType { }
    enum ShieldType { }
    class Creep : PrimaryObject
    {
        CreepType creepType;

        public double percentageOfLifeLossOnFailure;
        bool dead;

    }
}
