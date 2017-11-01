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
    enum ObjectResourceType { }
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

        private List<Attack> attacks;
        public List<Constraint> targetConstraints;

        private Dictionary<ObjectResourceType, int> objectResources;
        private Dictionary<DamageType, int> armorPts;

        public int lifePts { get; set; }
        public ShieldType shieldType { get; set; }
        public int shieldPts { get; set; }

        public PrimaryObject()
        {
            lock(lockObject)
            {
                uniqueID = uIDCounter;
                uIDCounter++;
            }
        }
    }
}
