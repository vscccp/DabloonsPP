using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace DabloonsPP.GameObjects.Towers
{
    enum SuperTower_Prices
    {
        TowerPrice = 2500,
        FirstPath_1 = 2500,
        FirstPath_2 = 3000,
        FirstPath_3 = 20000,
        SecondPath_1 = 1000,
        SecondPath_2 = 1400,
        SecondPath_3 = 8000,
        ThirdPath_1 = 3000,
        ThirdPath_2 = 1200,
        ThirdPath_3 = 5600
    }

    internal class SuperTower : ITower
    {
        private int projectile_speed = 50;
        private int pierce = 1;
        private static int width = 75;
        private static int height = 75;
        public SuperTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu, ChangeSelectedTower changeSelectedTower, AddMoneyForPop addMoneyForPop) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\super_monkey.png", canva, damage, 300, enemies, TimeSpan.FromMilliseconds(100), tryReduceMoney, OpenUpgradeMenu, changeSelectedTower, addMoneyForPop)
        {
            moneySpent = (int)BasicTower_Prices.TowerPrice;
        }

        public override void Upgrade_Tower(Paths path)
        {

        }

        protected override void Shoot(double angle)
        {
            // Calculate the velocity components
            double speed = projectile_speed;
            int vx = (int)(speed * Math.Cos(angle));
            int vy = (int)(speed * Math.Sin(angle));

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, "Projectiles\\dart.png", (float)angle, GameCanvas, enemies, addMoneyForPop);
        }
    }
}
