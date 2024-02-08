using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.ComponentModel;

namespace DabloonsPP.GameObjects.Towers
{
    enum NinjaTower_Prices
    {
        TowerPrice = 500,
        FirstPath_1 = 300,
        FirstPath_2 = 350,
        FirstPath_3 = 850,
        SecondPath_1 = 350,
        SecondPath_2 = 500,
        SecondPath_3 = 900,
        ThirdPath_1 = 250,
        ThirdPath_2 = 400,
        ThirdPath_3 = 2750
    }

    internal class NinjaTower : ITower
    {
        private int projectile_speed = 50;
        private int pierce = 2;
        private static int width = 75;
        private static int height = 75;
        private int shots = 1;
        public NinjaTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu, ChangeSelectedTower changeSelectedTower, AddMoneyForPop addMoneyForPop) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\ninja_monkey.png", canva, damage, 250, enemies, TimeSpan.FromMilliseconds(550), tryReduceMoney, OpenUpgradeMenu, changeSelectedTower, addMoneyForPop)
        {
            firstPath_Price = (int)NinjaTower_Prices.FirstPath_1;
            secondPath_Price = (int)NinjaTower_Prices.SecondPath_1;
            thirdPath_Price = (int)NinjaTower_Prices.ThirdPath_1;

            moneySpent = (int)NinjaTower_Prices.TowerPrice;
        }

        public override void Upgrade_Tower(Paths path)
        {
            if (path == Paths.FirstPath)
            {
                UpgradeFirstPath();
            }
            else if (path == Paths.SecondPath)
            {
                UpgradeSecondPath();
            }
            else if (path == Paths.ThirdPath)
            {
                UpgradeThirdPath();
            }
        }

        private void UpgradeFirstPath()
        {
            switch (firstPath)
            {
                case 0:
                    if (tryReduceMoney((int)NinjaTower_Prices.FirstPath_1))
                    {
                        damage++;
                        pierce++;
                        firstPath_Price = (int)NinjaTower_Prices.FirstPath_2;
                        firstPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)NinjaTower_Prices.FirstPath_2))
                    {
                        // Perform upgrade specific to first path and level 1
                        damage++;
                        shots++;
                        firstPath_Price = (int)NinjaTower_Prices.FirstPath_3;
                        firstPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)NinjaTower_Prices.FirstPath_3))
                    {
                        // Perform upgrade specific to first path and level 2
                        damage++;
                        shots += 2;
                        firstPath_Price = 0;
                        firstPath++;
                    }
                    break;
            }
        }

        private void UpgradeSecondPath()
        {
            switch (secondPath)
            {
                case 0:
                    if (tryReduceMoney((int)NinjaTower_Prices.SecondPath_1))
                    {
                        // Perform upgrade specific to second path and level 0
                        ShootCooldown -= TimeSpan.FromMilliseconds(120);
                        secondPath_Price = (int)NinjaTower_Prices.SecondPath_2;
                        secondPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)NinjaTower_Prices.SecondPath_2))
                    {
                        // Perform upgrade specific to second path and level 1
                        ShootCooldown -= TimeSpan.FromMilliseconds(150);
                        secondPath_Price = (int)NinjaTower_Prices.SecondPath_3;
                        secondPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)NinjaTower_Prices.SecondPath_3))
                    {
                        // Perform upgrade specific to second path and level 2
                        ShootCooldown -= TimeSpan.FromMilliseconds(200);
                        secondPath_Price = 0;
                        secondPath++;
                    }
                    break;
            }
        }

        private void UpgradeThirdPath()
        {
            switch (thirdPath)
            {
                case 0:
                    if (tryReduceMoney((int)NinjaTower_Prices.ThirdPath_1))
                    {
                        // Perform upgrade specific to third path and level 0
                        range += 10;
                        thirdPath_Price = (int)NinjaTower_Prices.ThirdPath_2;
                        thirdPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)NinjaTower_Prices.ThirdPath_2))
                    {
                        // Perform upgrade specific to third path and level 1
                        range += 20;
                        thirdPath_Price = (int)NinjaTower_Prices.ThirdPath_3;
                        thirdPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)NinjaTower_Prices.ThirdPath_3))
                    {
                        // Perform upgrade specific to third path and level 2
                        damage += 2;
                        pierce++;
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

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, "Projectiles\\shurikan.png", (float)angle, GameCanvas, enemies, addMoneyForPop);
        }
    }
}
