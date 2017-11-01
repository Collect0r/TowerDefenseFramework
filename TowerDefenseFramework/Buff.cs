using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    // permanent, timed, 
    // override rule: NO_EFFECT,
    enum BuffOverrideRule { NO_EFFECT, STACK, TIME_RESET, STACK_TIME_RESET }

    abstract class Buff
    {
        protected abstract bool apply(PrimaryObject source, PrimaryObject target);

        protected abstract void remove(PrimaryObject source, PrimaryObject target);

        protected abstract BuffOverrideRule getBuffOverrideRule();
    }
}
