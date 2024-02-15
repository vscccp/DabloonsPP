using DabloonsPP.GameObjects.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement.Core;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    enum BoomerangTower_Prices
    {
        TowerPrice = 325,
        FirstPath_1 = 200,
        FirstPath_2 = 280,
        FirstPath_3 = 1300,
        SecondPath_1 = 175,
        SecondPath_2 = 250,
        SecondPath_3 = 1450,
        ThirdPath_1 = 100,
        ThirdPath_2 = 300,
        ThirdPath_3 = 1300
    }

    internal class BoomerangTower : ITower
    {
        static private readonly int RANGE = 200;
        private int projectile_speed = 50;
        private int pierce = 4;
        private static int width = 100;
        private static int height = 100;
        public BoomerangTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu, ChangeSelectedTower changeSelectedTower, AddMoneyForPop addMoneyForPop) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\boomerang_monkey.png", canva, damage, RANGE, enemies, TimeSpan.FromMilliseconds(800), tryReduceMoney, OpenUpgradeMenu, changeSelectedTower, addMoneyForPop)
        {
            projectilePath = "Projectiles/boomerang.png";

            firstPath_Price = (int)BoomerangTower_Prices.FirstPath_1;
            secondPath_Price = (int)BoomerangTower_Prices.SecondPath_1;
            thirdPath_Price = (int)BoomerangTower_Prices.ThirdPath_1;

            moneySpent = (int)BoomerangTower_Prices.TowerPrice;
        }

        protected override void UpgradeFirstPath()
        {
            switch (firstPath)
            {
                case 0:
                    if (!(pathsChosen == 2) && tryReduceMoney((int)BoomerangTower_Prices.FirstPath_1))
                    {
                        pierce *= 2;
                        firstPath_Price = (int)BoomerangTower_Prices.FirstPath_2;
                        firstPath++;
                        pathsChosen++;
                        moneySpent += (int)BoomerangTower_Prices.FirstPath_1; // Increase money spent
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BoomerangTower_Prices.FirstPath_2))
                    {
                        // Perform upgrade specific to first path and level 1
                        damage += 2;
                        projectile_speed = (int)(projectile_speed*1.3);
                        firstPath_Price = (int)BoomerangTower_Prices.FirstPath_3;
                        firstPath++;
                        moneySpent += (int)BoomerangTower_Prices.FirstPath_2; // Increase money spent
                    }
                    break;
                case 2:
                    if (!maxPath && tryReduceMoney((int)BoomerangTower_Prices.FirstPath_3))
                    {
                        // Perform upgrade specific to first path and level 2
                        damage += 3;
                        projectile_speed = (int)(projectile_speed * 1.2);
                        firstPath_Price = 0;
                        firstPath++;
                        maxPath = true;
                        moneySpent += (int)BoomerangTower_Prices.FirstPath_3; // Increase money spent
                    }
                    break;
            }
        }

        protected override void UpgradeSecondPath()
        {
            switch (secondPath)
            {
                case 0:
                    if (!(pathsChosen == 2) && tryReduceMoney((int)BoomerangTower_Prices.SecondPath_1))
                    {
                        // Perform upgrade specific to second path and level 0
                        ShootCooldown -= TimeSpan.FromMilliseconds(120);
                        secondPath_Price = (int)BoomerangTower_Prices.SecondPath_2;
                        secondPath++;
                        pathsChosen++;
                        moneySpent += (int)BoomerangTower_Prices.SecondPath_1; // Increase money spent
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BoomerangTower_Prices.SecondPath_2))
                    {
                        // Perform upgrade specific to second path and level 1
                        ShootCooldown -= TimeSpan.FromMilliseconds(150);
                        secondPath_Price = (int)BoomerangTower_Prices.SecondPath_3;
                        secondPath++;
                        moneySpent += (int)BoomerangTower_Prices.SecondPath_2; // Increase money spent
                    }
                    break;
                case 2:
                    if (!maxPath && tryReduceMoney((int)BoomerangTower_Prices.SecondPath_3))
                    {
                        // Perform upgrade specific to second path and level 2
                        ShootCooldown -= TimeSpan.FromMilliseconds(200);
                        secondPath_Price = 0;
                        secondPath++;
                        maxPath = true;
                        moneySpent += (int)BoomerangTower_Prices.SecondPath_3; // Increase money spent
                    }
                    break;
            }
        }

        protected override void UpgradeThirdPath()
        {
            switch (thirdPath)
            {
                case 0:
                    if (!(pathsChosen == 2) && tryReduceMoney((int)BoomerangTower_Prices.ThirdPath_1))
                    {
                        // Perform upgrade specific to third path and level 0
                        range += 10;
                        thirdPath_Price = (int)BoomerangTower_Prices.ThirdPath_2;
                        thirdPath++;
                        pathsChosen++;
                        moneySpent += (int)BoomerangTower_Prices.ThirdPath_1; // Increase money spent
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BoomerangTower_Prices.ThirdPath_2))
                    {
                        // Perform upgrade specific to third path and level 1
                        range += 20;
                        thirdPath_Price = (int)BoomerangTower_Prices.ThirdPath_3;
                        thirdPath++;
                        moneySpent += (int)BoomerangTower_Prices.ThirdPath_2; // Increase money spent
                    }
                    break;
                case 2:
                    if (!maxPath && tryReduceMoney((int)BoomerangTower_Prices.ThirdPath_3))
                    {
                        // Perform upgrade specific to third path and level 2
                        damage++;
                        range += 15;
                        thirdPath_Price = 0;
                        thirdPath++;
                        maxPath = true;
                        moneySpent += (int)BoomerangTower_Prices.ThirdPath_3; // Increase money spent
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

            BoomerangProjectile projectile = new BoomerangProjectile(Position.X, Position.Y, vx, vy, damage, pierce, RANGE, projectilePath, (float)angle, GameCanvas, enemies, false, false);
        }
    }
}
