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
        private int projectile_speed = 50;
        private int pierce = 2;
        public BasicTower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<IEnemy> enemeies) : base(width, height, x, y, path, canva, damage, range, enemies)
        {}

        protected override void Shoot(IEnemy target)
        {
            // Calculate direction to shoot
            int deltaX = Position.X - target.Position.X;
            int deltaY = Position.Y - target.Position.Y;

            double distance = Math.Sqrt(Math.Pow(deltaX ,2) + Math.Pow(deltaY, 2));

            if (distance > range)
                return;

            // Calculate the angle in radians
            double angle = Math.Atan2(deltaY, deltaX);
            double angleDegrees = angle * (180.0 / Math.PI);

            // Calculate the velocity components
            double speed = projectile_speed;
            int vx = (int)(speed * Math.Cos(angle));
            int vy = (int)(speed * Math.Sin(angle));

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, "Assets\\Projectiles\\Dart.png", (float)angleDegrees, GameCanvas);
        }

    }
}
