﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework
{
    class ProjectileNormal : AProjectile
    {
        public ProjectileNormal(PrimaryObject source, PrimaryObject target, DamageType dmgType, int damage, int speed, int acceleration) : base(source, target, dmgType, damage, speed, acceleration)
        {

        }

    }
}
