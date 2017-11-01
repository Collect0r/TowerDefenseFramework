using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Constraints;
using TowerDefenseFramework.CustomEventArgs;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    enum TargetSelect { FIRST, HP_MOST, HP_LEAST, CLOSEST, FARTHEST, RANDOM_TARGET, RANDOM_WITHIN_RANGE, RANDOM_MAX_RANGE }
    enum TargetChange { STICK_TO_TARGET, RESELECT, RESELECT_NOT_TWICE }
    abstract class Attack
    {
        public PrimaryObject source;
        TargetSelect targetSelectType;
        TargetChange targetChangeType;
        DamageType dmgType;
        private int attackRangeSq;
        private int startSpeed;
        private int acceleration;
        List<Constraint> targetConstraints;
        List<PrimaryObject> validTargetsInRange;
        bool waitingForAttackableObject;

        Random dmgRandomizer;

        public void setValidTargetsInRange(List<PrimaryObject> newValidTargetsInRange)
        {
            validTargetsInRange = newValidTargetsInRange;
        }

        public void attack(List<PrimaryObject> allPossibleTargets) // ToDo: targets in range als parameter
        {
            //ToDo: select targets in range auslagern in glbale Klasse (RangeEventRaiser -> umbenennen)
            Projectile[] projectiles = createProjectiles(selectValidTargets(selectTargetsInRange(allPossibleTargets)), targetSelectType);

            
        }

        List<PrimaryObject> selectTargetsInRange(List<PrimaryObject> allPossibleTargets)
        {
            return allPossibleTargets.Where(c => HelperMethods.distanceSq_int(source.posCenter, c.posCenter) <= attackRangeSq).ToList();
        }

        List<PrimaryObject> selectValidTargets(List<PrimaryObject> targetsInRange)
        {
            return targetsInRange.Where(c => checkTargetConstraints(c)).ToList();
        }

        bool checkTargetConstraints(PrimaryObject target)
        {
            foreach (Constraint constraint in targetConstraints.Concat(source.targetConstraints))
            {
                if (!constraint.isAllowed(source, target))
                    return false;
            }
            return true;
        }
        
        public abstract Projectile[] createProjectiles(List<PrimaryObject> validTargetsInRange, TargetSelect targetSelectType);

        //public void incPercDmg(double amount)
        //{
        //    dmgInc_Perc += amount;
        //}

        //public void incAbsDmg(int amount)
        //{
        //    dmgInc_Abs += amount;
        //}
    }
}
