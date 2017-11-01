using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.CustomEventArgs;

namespace TowerDefenseFramework
{
    enum CreepType { a, b }
    class Creep : PrimaryObject
    {
        public CreepType creepType;

        public double percentageOfLifeLossOnFailure;
        bool dead;
        
    }
}
