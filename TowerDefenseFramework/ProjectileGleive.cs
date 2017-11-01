using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    class ProjectileGleive : AProjectile
    {
        public ProjectileGleive(PrimaryObject source, PrimaryObject target, DamageType dmgType, int damage, int speed, int acceleration, int remainingNumberOfTargets) : base(source, target, dmgType, damage, speed, acceleration)
        {
        }
    }
}
