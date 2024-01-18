using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    abstract class ITower : IGameObject
    {
        public int damage { get; set; }
        public float range { get; set; }

        protected List<IEnemy> enemies;
        protected abstract void Shoot(IEnemy target);



        public ITower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<IEnemy> enemeies) : base(width, height, x, y, path, canva)
        {
            this.damage = damage;
            this.range = range;
            this.enemies = enemeies;

            this.hitbox = null;
        }
    }
}
