using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework.CustomEventArgs
{
    class OnDoHitEventArgs : EventArgs
    {
        public PrimaryObject source;
        public PrimaryObject target;
        public DamageType dmgType;
        public int dmg;
    }
}
