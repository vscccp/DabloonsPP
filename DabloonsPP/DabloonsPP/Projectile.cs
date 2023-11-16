using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabloonsGG1
{
    class Projectile : IGameObject
    {
        public float dx;
        public float dy;

        public float damage;

        public Projectile(float dx, float dy, float damage)
        {
            this.dx = dx;
            this.dy = dy;

            this.damage = damage;
        }
    }
}
