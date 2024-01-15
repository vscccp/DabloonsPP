using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    class Projectile : IGameObject
    {
        const int PROJECTILE_WIDTH = 20;
        const int PROJECTILE_HEIGHT = 20;

        public float dx;
        public float dy;

        public float damage;

        public float Dx
        {
            get { return dx; }
            set { dx = value; }
        }

        public float Dy
        {
            get { return dy; }
            set { dy = value; }
        }

        public float Damage
        {
            get { return damage; }
        }

        public Projectile(int x, int y, float dx, float dy, float damage, string path, Canvas canva) :
            base(PROJECTILE_WIDTH, PROJECTILE_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;

            this.damage = damage;
        }
    }
}
