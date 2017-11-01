using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    enum GameResourceType { }
    class Game
    {
        public List<Creep> livingCreeps_currentOrder;
        public List<Tower> towers;
        public List<Projectile> projectiles;

        List<KeyValuePair<GameResourceType, int>> gameResources;
        CreepWave currentCreepWave;

        List<Creep> getCreepsInRange(Point towerPos, int rangeSq)
        {
            return livingCreeps_currentOrder.Where(c => (HelperMethods.distanceSq_int(towerPos, c.posCenter) < rangeSq)).ToList();
        }
    }
}
