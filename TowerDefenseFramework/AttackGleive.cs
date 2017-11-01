using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    class AttackGleive : Attack
    {
        int numberOfBounces;

        public override PrimaryObject[] selectFinalTargets(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType)
        {
            throw new NotImplementedException();
        }
    }
}
