using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    // attacks and abilities
    interface IHasRange
    {
        int getRange();
        void setTargetsInRange(List<PrimaryObject> newTargetsInRange);
    }
}
