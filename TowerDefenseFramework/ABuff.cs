using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    // permanent, timed, 
    // override rule: NO_EFFECT,
    enum BuffOverrideRule { REFUSE, STACK, SINGLE_TIME_RESET, STACK_TIME_RESET }

    abstract class ABuff
    {
        int currentStackSize;
        // List

        public bool applyAndWatch(PrimaryObject holder)
        {
            switch(getBuffOverrideRule())
            {
                case BuffOverrideRule.NO_EFFECT:

                    break;

                case BuffOverrideRule.STACK:

                    break;

                case BuffOverrideRule.TIME_RESET:

                    break;

                case BuffOverrideRule.STACK_TIME_RESET:

                    break;
            }
        }

        protected abstract bool apply(PrimaryObject target);

        protected abstract void remove(PrimaryObject target);

        protected abstract BuffOverrideRule getBuffOverrideRule();

        // negative value => permanent
        protected abstract double getDuration();

        protected abstract bool getMaximumStackSize();
    }
}
