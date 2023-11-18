using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    class IEnemy : IGameObject
    {
        const int ENEMY_HEIGHT = 100;
        const int ENEMY_WIDTH = 125;

        public int dx;
        public int dy;
        public int health;

        private DispatcherTimer moveTimer;
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }

        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public IEnemy(int x, int y, string path, Canvas canva, int dx, int dy, int health) :
            base(ENEMY_WIDTH, ENEMY_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;
            this.health = health;

            moveTimer = new DispatcherTimer();
            moveTimer.Interval = TimeSpan.FromTicks(20);
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        private void MoveTimer_Tick(object sender, object e)
        {
            position.X += dx;
            position.Y += dy;

            Draw();
        }
    }
}
