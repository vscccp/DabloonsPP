using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP.GameObjects.Towers
{
    class BasicTower : ITower
    {
        public BasicTower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range) : base(width, height, x, y, path, canva, damage, range)
        {

        }

        protected override void Shoot(IEnemy target)
        {
            // Calculate direction to shoot
            int deltaX = Position.X - target.Position.X;
            int deltaY = Position.Y - target.Position.Y;

            double distance = Math.Sqrt(Math.Pow(deltaX ,2) + Math.Pow(deltaY, 2));

            if (distance > range)
                return;

            int vx = 0;
            int vy = 0;

            
        }

    }
}
