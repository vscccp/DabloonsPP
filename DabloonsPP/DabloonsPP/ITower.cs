using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabloonsGG1
{
    abstract class ITower : IGameObject
    {
        public float damage;
        public float range;

        protected abstract void Shoot();
    }
}
