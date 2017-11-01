using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{

    // Implements a permanent loop that checks if a PrimaryObject enters the range of an attack or an ability (so also for auras) and raises the event if so
    class GameLoops
    {
        List<IHasRange> objectsWithRange;
        Game currentGame;
        
        public void checkRange()
        {
            List<PrimaryObject> targets = new List<PrimaryObject>(currentGame.livingCreeps_currentOrder); // shallow copy

            foreach (IHasRange obj in objectsWithRange)
            {
                obj.setTargetsInRange()
                foreach (PrimaryObject target in targets)
                {

                }
            }
        }
    }
}
