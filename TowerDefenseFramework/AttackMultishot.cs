using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    class AttackMultishot : Attack
    {
        int numberOfTargets;

        public override PrimaryObject[] selectFinalTargets(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType)
        {
            switch (targetSelectType)
            {
                case TargetSelect.FIRST:
                    return validTargetsInRange.Take(numberOfTargets).ToArray();
                case TargetSelect.HP_MOST:
                    return validTargetsInRange.OrderBy(c => c.lifePts).Skip(validTargetsInRange.Count - numberOfTargets).ToArray();
                case TargetSelect.HP_LEAST:
                    return validTargetsInRange.OrderBy(c => c.lifePts).Take(numberOfTargets).ToArray();
                case TargetSelect.CLOSEST:
                    return validTargetsInRange.OrderBy(c => HelperMethods.distanceSq_int(c.posCenter, source.posCenter)).Take(numberOfTargets).ToArray();
                case TargetSelect.FARTHEST:
                    return validTargetsInRange.OrderBy(c => -HelperMethods.distanceSq_int(c.posCenter, source.posCenter)).Skip(validTargetsInRange.Count - numberOfTargets).ToArray();
                case TargetSelect.RANDOM_TARGET:
                    Random rnd = new Random();
                    return validTargetsInRange.OrderBy(c => rnd.Next()).Take(numberOfTargets).ToArray();
            }

            return new PrimaryObject[] { };
        }
    }
}
