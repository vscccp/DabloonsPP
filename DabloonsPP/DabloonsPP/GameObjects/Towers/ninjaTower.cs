using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Diagnostics;

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
            projectilePath = "Projectiles/Shurikan.png";

            firstPath_Price = (int)NinjaTower_Prices.FirstPath_1;
            secondPath_Price = (int)NinjaTower_Prices.SecondPath_1;
            thirdPath_Price = (int)NinjaTower_Prices.ThirdPath_1;

            moneySpent = (int)NinjaTower_Prices.TowerPrice;

            canShootCamo = true;
        }

        protected override void UpgradeFirstPath()
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
                        shots *= 2;
                        firstPath_Price = (int)NinjaTower_Prices.FirstPath_3;
                        firstPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)NinjaTower_Prices.FirstPath_3))
                    {
                        // Perform upgrade specific to first path and level 2
                        damage++;
                        shots *= 2;
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

        protected override void UpgradeThirdPath()
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

            // Calculate the angle between shots
            double angleBetweenShots = Math.PI / 20;

            // Determine the number of shots above and below the angle
            int shotsAbove = shots / 2;
            int shotsBelow = shots - shotsAbove;

            // Loop to create multiple projectiles
            for (int i = 0; i < shotsAbove; i++)
            {
                // Calculate the angle for this shot above the angle
                double shotAngle = angle + (i * angleBetweenShots);
                Debug.WriteLine(shotAngle);
                // Calculate the velocity components for this shot
                int vx = (int)(speed * Math.Cos(shotAngle));
                int vy = (int)(speed * Math.Sin(shotAngle));

                // Create the projectile
                Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, projectilePath, (float)shotAngle, GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
            }

            for (int i = 1; i <= shotsBelow; i++) // Start from 1 to avoid duplicate shot at the exact angle
            {
                // Calculate the angle for this shot below the angle
                double shotAngle = angle - (i * angleBetweenShots);
                Debug.WriteLine(shotAngle);
                // Calculate the velocity components for this shot
                int vx = (int)(speed * Math.Cos(shotAngle));
                int vy = (int)(speed * Math.Sin(shotAngle));

                // Create the projectile
                Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, projectilePath, (float)shotAngle, GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
            }
        }
    }
}
