using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    enum BasicTower_Prices
    {
        TowerPrice   = 200,
        FirstPath_1  = 140,
        FirstPath_2  = 220,
        FirstPath_3  = 300,
        SecondPath_1 = 100,
        SecondPath_2 = 190,
        SecondPath_3 = 400,
        ThirdPath_1  = 90,
        ThirdPath_2  = 200,
        ThirdPath_3  = 625
    }

    class BasicTower : ITower
    {
        private int projectile_speed = 50;
        private int pierce = 2;
        private static int width = 75;
        private static int height = 75;

        private bool tripleShot = false;
        public BasicTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu, ChangeSelectedTower changeSelectedTower, AddMoneyForPop addMoneyForPop) : 
            base(width, height, (x-(width/2)), (y-(height/2)), "Monkeys\\dartMonkey.png", canva, damage, 200, enemies, TimeSpan.FromMilliseconds(750), tryReduceMoney, OpenUpgradeMenu, changeSelectedTower, addMoneyForPop)
        {
            projectilePath = "Projectiles/Dart.png";

            firstPath_Price = (int)BasicTower_Prices.FirstPath_1;
            secondPath_Price = (int)BasicTower_Prices.SecondPath_1;
            thirdPath_Price = (int)BasicTower_Prices.ThirdPath_1;

            moneySpent = (int)BasicTower_Prices.TowerPrice;
        }

        protected override void UpgradeFirstPath()
        {
            switch (firstPath)
            {
                case 0:
                    if (tryReduceMoney((int)BasicTower_Prices.FirstPath_1))
                    {
                        pierce++;
                        firstPath_Price = (int)BasicTower_Prices.FirstPath_2;
                        firstPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BasicTower_Prices.FirstPath_2))
                    {
                        // Perform upgrade specific to first path and level 1
                        pierce += 2;
                        firstPath_Price = (int)BasicTower_Prices.FirstPath_3;
                        firstPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)BasicTower_Prices.FirstPath_3))
                    {
                        // Perform upgrade specific to first path and level 2
                        damage++;
                        pierce += 15;
                        firstPath_Price = 0;
                        tripleShot = true;
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
                    if (tryReduceMoney((int)BasicTower_Prices.SecondPath_1))
                    {
                        // Perform upgrade specific to second path and level 0
                        ShootCooldown -= TimeSpan.FromMilliseconds(120);
                        secondPath_Price = (int)BasicTower_Prices.SecondPath_2;
                        secondPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BasicTower_Prices.SecondPath_2))
                    {
                        // Perform upgrade specific to second path and level 1
                        ShootCooldown -= TimeSpan.FromMilliseconds(150);
                        secondPath_Price = (int)BasicTower_Prices.SecondPath_3;
                        secondPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)BasicTower_Prices.SecondPath_3))
                    {
                        // Perform upgrade specific to second path and level 2
                        tripleShot = true;
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
                    if (tryReduceMoney((int)BasicTower_Prices.ThirdPath_1))
                    {
                        // Perform upgrade specific to third path and level 0
                        range += 10;
                        thirdPath_Price = (int)BasicTower_Prices.ThirdPath_2;
                        thirdPath++;
                    }
                    break;
                case 1:
                    if (tryReduceMoney((int)BasicTower_Prices.ThirdPath_2))
                    {
                        // Perform upgrade specific to third path and level 1
                        range += 20;
                        canShootCamo = true;
                        thirdPath_Price = (int)BasicTower_Prices.ThirdPath_3;
                        thirdPath++;
                    }
                    break;
                case 2:
                    if (tryReduceMoney((int)BasicTower_Prices.ThirdPath_3))
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

            if (tripleShot)
            {
                // Offset angles for triple shot
                double offsetAngle = Math.PI / 15; 

                // Create three projectiles with slightly different angles
                Projectile projectile1 = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, projectilePath, (float)angle, GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
                Projectile projectile2 = new Projectile(Position.X, Position.Y, (int)(speed * Math.Cos(angle + offsetAngle)), (int)(speed * Math.Sin(angle + offsetAngle)), damage, pierce, projectilePath, (float)(angle + offsetAngle), GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
                Projectile projectile3 = new Projectile(Position.X, Position.Y, (int)(speed * Math.Cos(angle - offsetAngle)), (int)(speed * Math.Sin(angle - offsetAngle)), damage, pierce, projectilePath, (float)(angle - offsetAngle), GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
            }
            else
            {
                // Create a single projectile
                Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, projectilePath, (float)angle, GameCanvas, enemies, addMoneyForPop, canShootCamo, canShootLead);
            }
        }
    }

}
