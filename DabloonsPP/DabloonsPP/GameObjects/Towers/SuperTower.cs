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
            projectilePath = "Projectiles/Dart.png";

            firstPath_Price = (int)SuperTower_Prices.FirstPath_1;
            secondPath_Price = (int)SuperTower_Prices.SecondPath_1;
            thirdPath_Price = (int)SuperTower_Prices.ThirdPath_1;

            moneySpent = (int)SuperTower_Prices.TowerPrice;
        }

        protected override void UpgradeFirstPath()
        {
            switch (firstPath)
            {
                case 0:
                    if (tryReduceMoney((int)SuperTower_Prices.FirstPath_1))
                    {
                        pierce++;
                        damage += 2;
                        canShootLead = true;
                        projectilePath = "Projectiles/Laser.png";
                        firstPath_Price = (int)SuperTower_Prices.FirstPath_2;
                        firstPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)SuperTower_Prices.FirstPath_2))
                    {
                        // Perform upgrade specific to first path and level 1
                        damage += 2;
                        projectile_speed = (int)(projectile_speed * 1.3);
                        firstPath_Price = (int)SuperTower_Prices.FirstPath_3;
                        firstPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)SuperTower_Prices.FirstPath_3))
                    {
                        // Perform upgrade specific to first path and level 2
                        damage += 3;
                        projectile_speed = (int)(projectile_speed * 1.2);
                        firstPath_Price = 0;
                        firstPath++;
                    }
                    break;
            }
        }

        protected override void UpgradeSecondPath()
        {
            switch (secondPath)
            {
                case 0:
                    if (tryReduceMoney((int)SuperTower_Prices.SecondPath_1))
                    {
                        // Perform upgrade specific to second path and level 0

                        secondPath_Price = (int)SuperTower_Prices.SecondPath_2;
                        secondPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)SuperTower_Prices.SecondPath_2))
                    {
                        // Perform upgrade specific to second path and level 1

                        secondPath_Price = (int)SuperTower_Prices.SecondPath_3;
                        secondPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)SuperTower_Prices.SecondPath_3))
                    {
                        // Perform upgrade specific to second path and level 2

                        secondPath_Price = 0;
                        secondPath++;
                    }
                    break;
            }
        }

        protected override void UpgradeThirdPath()
        {
            switch (thirdPath)
            {
                case 0:
                    if (tryReduceMoney((int)SuperTower_Prices.ThirdPath_1))
                    {
                        // Perform upgrade specific to third path and level 0
                        range += 15;
                        thirdPath_Price = (int)SuperTower_Prices.ThirdPath_2;
                        thirdPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)SuperTower_Prices.ThirdPath_2))
                    {
                        // Perform upgrade specific to third path and level 1
                        range += 25;
                        canShootCamo = true;
                        thirdPath_Price = (int)SuperTower_Prices.ThirdPath_3;
                        thirdPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)SuperTower_Prices.ThirdPath_3))
                    {
                        // Perform upgrade specific to third path and level 2
                        damage++;
                        range += 20;
                        thirdPath_Price = 0;
                        thirdPath++;
                    }
                    break;
            }
        }

        protected override void Shoot(double angle)
        {
            // Calculate the velocity components
            double speed = projectile_speed;
            int vx = (int)(speed * Math.Cos(angle));
            int vy = (int)(speed * Math.Sin(angle));

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, projectilePath, (float)angle, GameCanvas, enemies, canShootCamo, canShootLead);
        }
    }
}
