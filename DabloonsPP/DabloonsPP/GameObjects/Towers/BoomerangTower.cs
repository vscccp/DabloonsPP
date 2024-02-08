using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP.GameObjects.Towers
{
    internal class BoomerangTower : ITower
    {
        static private readonly int RANGE = 300;
        private int projectile_speed = 50;
        private int pierce = 4;
        private static int width = 100;
        private static int height = 100;
        public BoomerangTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\boomerang_monkey.png", canva, damage, RANGE, enemies, TimeSpan.FromMilliseconds(800), tryReduceMoney, OpenUpgradeMenu)
        {
        }

        protected override void Upgrade_Tower(Paths path)
        {

        }

        protected override void Shoot(double angle)
        {
            // Calculate the velocity components
            double speed = projectile_speed;
            int vx = (int)(speed * Math.Cos(angle));
            int vy = (int)(speed * Math.Sin(angle));

            BoomerangProjectile projectile = new BoomerangProjectile(Position.X, Position.Y, vx, vy, damage, pierce, RANGE, "Projectiles\\boomerang.png", (float)angle, GameCanvas, enemies);
        }
    }
}
