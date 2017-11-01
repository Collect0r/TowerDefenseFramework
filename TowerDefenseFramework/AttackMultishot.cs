using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    class AttackMultishot : AAttack
    {
        int numberOfTargets;
        int maxProjectilesOnSameTarget;

        public override AProjectile[] createProjectiles(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType)
        {
            throw new NotImplementedException();
        }

        public override PrimaryObject[] selectFinalTargets(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType)
        {
            switch (targetSelectType)
            {
                case TargetSelect.FIRST:
                    return validTargetsInRange.Take(numberOfTargets).ToArray();
                case TargetSelect.HP_MOST:
                    return validTargetsInRange.OrderBy(c => c.getResource(ObjectResourceType.LIFE).getAmount()).Skip(validTargetsInRange.Count - numberOfTargets).ToArray();
                case TargetSelect.HP_LEAST:
                    return validTargetsInRange.OrderBy(c => c.getResource(ObjectResourceType.LIFE).getAmount()).Take(numberOfTargets).ToArray();
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
