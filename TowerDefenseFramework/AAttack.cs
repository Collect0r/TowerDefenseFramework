using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TowerDefenseFramework.Constraints;
using TowerDefenseFramework.CustomEventArgs;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    enum TargetSelect { FIRST, HP_MOST, HP_LEAST, CLOSEST, FARTHEST, RANDOM_TARGET, RANDOM_POS_IN_RANGE, RANDOM_POS_MAX_RANGE }
    enum TargetChange { STICK_TO_TARGET, RESELECT, RESELECT_NOT_TWICE }
    abstract class AAttack
    {
        Game game;
        public PrimaryObject source;
        protected TargetSelect targetSelectType;
        protected TargetChange targetChangeType;
        DamageType dmgType;
        private int attackRangeSq;
        private int startSpeed;
        private int acceleration;
        List<Constraint> targetConstraints;
        List<PrimaryObject> validTargetsInRange;
        List<PrimaryObject> previousTargets;
        List<Effect> 
        bool waitingForAttackableObject;

        Random dmgRandomizer;

        public void setValidTargetsInRange(List<PrimaryObject> newValidTargetsInRange)
        {
            validTargetsInRange = newValidTargetsInRange;
        }

        public void attack() // ToDo: targets in range als parameter
        {
            if (validTargetsInRange.Count == 0)
            {
                // attackTimer.Reset()
                waitingForAttackableObject = true;
            }

            AProjectile[] projectiles = createProjectiles(validTargetsInRange);
            game.projectiles.AddRange(projectiles);
        }

        public void calcValidTargetsInRange(List<PrimaryObject> allPossibleTargets)
        {
            validTargetsInRange =  allPossibleTargets.Where(c => HelperMethods.distanceSq_int(source.posCenter, c.posCenter) <= attackRangeSq).Where(c => checkTargetConstraints(c)).ToList();

            if (validTargetsInRange.Count > 0 && waitingForAttackableObject)
            {
                waitingForAttackableObject = false;
                attack();
                // attackTimer.Start();
            }
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
        
        public abstract AProjectile[] createProjectiles(List<PrimaryObject> validTargetsInRange);

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
