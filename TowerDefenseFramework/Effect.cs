using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    abstract class Effect
    {
        public bool execute(PrimaryObject source, PrimaryObject target)
        {
            EffectWatcher watcher = createEffectWatcher();
            watcher.applyAndWatch(apply, remove, source, target);
        }
        
        protected abstract EffectWatcher createEffectWatcher();
    }
}
