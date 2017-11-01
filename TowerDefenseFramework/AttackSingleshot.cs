using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    class AttackSingleshot : Attack
    {
        public override Projectile[] createProjectiles(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType)
        {
            PrimaryObject target;
            switch (targetSelectType)
            {
                case TargetSelect.FIRST:
                    target = validTargetsInRange[0];
                    break;
                case TargetSelect.HP_MOST:
                    target = validTargetsInRange.Aggregate((curMax, c) => (curMax == null || c.lifePts > curMax.lifePts) ? c : curMax); // O(n)
                    break;
                case TargetSelect.HP_LEAST:
                    target = validTargetsInRange.Aggregate((curMin, c) => (curMin == null || c.lifePts < curMin.lifePts) ? c : curMin); // O(n)
                    break;
                case TargetSelect.CLOSEST:
                    target = validTargetsInRange.Aggregate((curMin, c) => (curMin == null || HelperMethods.distanceSq_int(c.posCenter, source.posCenter) < HelperMethods.distanceSq_int(curMin.posCenter, source.posCenter)) ? c : curMin); // O(n)
                    break;
                case TargetSelect.FARTHEST:
                    target = validTargetsInRange.Aggregate((curMax, c) => (curMax == null || HelperMethods.distanceSq_int(c.posCenter, source.posCenter) > HelperMethods.distanceSq_int(curMax.posCenter, source.posCenter)) ? c : curMax); // O(n)
                    break;
                case TargetSelect.RANDOM_TARGET:
                    int index = (new Random()).Next(validTargetsInRange.Count);
                    target = validTargetsInRange[index];
                    break;
                default:
                    target = null;
                    break;
            }

            Projectile projectile = new Projectile(source, target, dmgType, (int)(dmgRandomizer.Next(baseDmgMin, baseDmgMax + 1) * dmgInc_Perc) + dmgInc_Abs, startSpeed, acceleration);

        }
    }
}
