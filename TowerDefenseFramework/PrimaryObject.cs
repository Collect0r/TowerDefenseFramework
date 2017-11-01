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
    enum ObjectResourceType { LIFE, MANA, SHIELD }

    /// <summary>
    /// Primary objects are towers, creeps or potentially heroes
    /// </summary>
    abstract class PrimaryObject
    {
        static object lockObject = new object();
        static ulong uIDCounter;
        ulong uniqueID;

        public EventHandler<OnDeathEventArgs> OnDeath;
        public EventHandler<OnGetHitEventArgs> OnGetHit;
        public EventHandler<OnDoHitEventArgs> OnDoHit;
        
        public Point posCenter { get; set; }

        private List<AAttack> attacks;
        public List<Constraint> targetConstraints;
        public List<ABuff> buffs;
        public List<ABuff> debuffs;

        private Dictionary<ObjectResourceType, BaseStat> objectResources;
        private Dictionary<DamageType, BaseStat> armorPts;
        

        public PrimaryObject(Dictionary<ObjectResourceType, BaseStat> objectResources, Dictionary<DamageType, BaseStat> armorPts)
        {
            lock(lockObject)
            {
                uniqueID = uIDCounter;
                uIDCounter++;
            }
            this.objectResources = objectResources;
            this.armorPts = armorPts;
        }

        public BaseStat getResource(ObjectResourceType resourceType)
        {
            return objectResources[resourceType];
        }
    }
}
