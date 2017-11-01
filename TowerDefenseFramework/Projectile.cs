using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseFramework.Helper;

namespace TowerDefenseFramework
{
    enum DamageType { }
    enum ProjectileStatus { APPROACHING, TARGET_DEAD, TARGET_REACHED }
    enum ProjectileType { MOVING, INSTANT, CHAIN }

    // ToDo: Make this abstract!!! 
    // Gleive attacks give projectiles an event to jump to next target
    // wie dann den deminishing return reinmachen?? werte für dmg decrease in das event?? geht das? -> eig schon, neues projektil

        // Constrainable implementieren??? Sodass immer constraints vom parent automatisch mitgetestet werden
    class Projectile
    {
        Point position;
        private PrimaryObject source;
        private PrimaryObject target;
        private DamageType dmgType;
        private int damage;
        private int speed;
        private int acceleration;

        public Projectile(PrimaryObject source, PrimaryObject target, DamageType dmgType, int damage, int speed, int acceleration)
        {
            this.source = source;
            this.target = target;
            this.dmgType = dmgType;
            this.damage = damage;
            this.speed = speed;
            this.acceleration = acceleration;
            position = source.posCenter;
        }

        public Projectile(PrimaryObject source, List<PrimaryObject> targets, DamageType dmgType, int damage, int speed, int acceleration)
        {
            this.source = source;
            this.target = target;
            this.dmgType = dmgType;
            this.damage = damage;
            this.speed = speed;
            this.acceleration = acceleration;
            position = source.posCenter;
        }

        public void move(double timeDelta)
        {
            if (acceleration != 0)
                speed = speed + (int)Math.Round(acceleration * timeDelta);

            position = HelperMethods.moveInDirection(position, HelperMethods.calcDirectionVector(position, target.posCenter), speed, timeDelta);
            
        }
    }
}
