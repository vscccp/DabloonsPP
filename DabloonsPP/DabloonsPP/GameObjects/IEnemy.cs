using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    class IEnemy : IGameObject
    {
        const int ENEMY_HEIGHT = 100;
        const int ENEMY_WIDTH = 125;

        public float dx;
        public float dy;
        public float health;

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

        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public IEnemy(int x, int y, string path, Canvas canva, float dx, float dy, float health) :
            base(ENEMY_WIDTH, ENEMY_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;
            this.health = health;
        }
    }
}
