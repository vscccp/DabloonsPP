using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace DabloonsPP.GameObjects.Towers
{
    internal class SuperTower : ITower
    {
        private int projectile_speed = 50;
        private int pierce = 1;
        private static int width = 75;
        private static int height = 75;
        public SuperTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\super_monkey.png", canva, damage, 300, enemies, TimeSpan.FromMilliseconds(100), tryReduceMoney, OpenUpgradeMenu)
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

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, "Projectiles\\dart.png", (float)angle, GameCanvas, enemies);
        }
    }
}
