using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    enum EffectRemoveOption { NEVER, TIMED}
    abstract class EffectWatcher
    {
        Func<PrimaryObject, PrimaryObject> applyEffectAction;
        Action<PrimaryObject, PrimaryObject> removeEffectAction;
        
        public void applyAndWatch(Action<PrimaryObject, PrimaryObject> applyEffectAction, Action<PrimaryObject, PrimaryObject> removeEffectAction, Effect effect, PrimaryObject source, PrimaryObject target)
        {
            this.applyEffectAction = applyEffectAction;
            this.removeEffectAction = removeEffectAction;


            bool wasApplied = applyEffectAction(source, target);


            Task.Factory.StartNew(() => startWatchingAsync());
        }

        private void startWatchingAsync()
        {

        }
    }
}
