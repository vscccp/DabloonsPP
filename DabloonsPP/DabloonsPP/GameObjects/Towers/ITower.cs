using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    enum TowerType
    {
        Basic = 0,
        ninja = 1,
        super = 2,
        boomerang = 3
    };

    enum Paths
    {
        FirstPath = 0,
        SecondPath = 1,
        ThirdPath = 2
    }

    delegate void changeMenu(TowerType tower,string PhotoPath1, string PhotoPath2, string PhotoPath3,int firstPath, int secondPath, int thirdPath, int price1, int price2, int price3);
    delegate void ChangeSelectedTower(ITower newTower);
    delegate bool TryReduceMoney(int money);
    

    abstract class ITower : IGameObject
    {
        #region Upgrade fields
        protected int firstPath = 0;
        protected int secondPath = 0;
        protected int thirdPath = 0;

        protected int firstPath_Price = 0;
        protected int secondPath_Price = 0;
        protected int thirdPath_Price = 0;

        protected int moneySpent = 0;
        #endregion

        public int damage { get; set; }
        public float range { get; set; }
        public TimeSpan ShootCooldown { get; set; }

        protected List<Bloon> enemies;
        private DateTime lastShootTime = DateTime.MinValue;
        private DispatcherTimer ChooseTimer;
        protected string projectilePath;

        protected changeMenu OpenUpgradeMenu;
        protected TryReduceMoney tryReduceMoney;
        protected ChangeSelectedTower changeSelectedTower;
        protected AddMoneyForPop addMoneyForPop;

        protected bool canShootCamo = false;
        protected bool canShootLead = false;
        protected bool maxPath = false;
        protected int pathsChosen = 0;


        public int FirstPath
        {
            get { return firstPath; }
            set { firstPath = value; }
        }

        public int SecondPath
        {
            get { return secondPath; }
            set { secondPath = value; }
        }

        public int ThirdPath
        {
            get { return thirdPath; }
            set { thirdPath = value; }
        }

        public int FirstPath_Price
        {
            get { return firstPath_Price; }
            set { firstPath_Price = value; }
        }

        public int SecondPath_Price
        {
            get { return secondPath_Price; }
            set { secondPath_Price = value; }
        }

        public int ThirdPath_Price
        {
            get { return thirdPath_Price; }
            set { thirdPath_Price = value; }
        }

        protected abstract void Shoot(double angle);

        public ITower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<Bloon> enemies,
            TimeSpan shootCooldown, TryReduceMoney tryReduceMoney, changeMenu OpenUpgradeMenu, ChangeSelectedTower changeSelectedTower, AddMoneyForPop addMoneyForPop)
            : base(width, height, x, y, path, canva)
        {
            this.changeSelectedTower = changeSelectedTower;
            this.OpenUpgradeMenu = OpenUpgradeMenu;
            this.tryReduceMoney = tryReduceMoney;
            this.addMoneyForPop = addMoneyForPop;
            this.damage = damage;
            this.range = range;
            this.enemies = enemies;
            this.ShootCooldown = shootCooldown;

            ChooseTimer = new DispatcherTimer();
            ChooseTimer.Interval = TimeSpan.FromTicks(20);
            ChooseTimer.Tick += ChooseTimer_Tick;

            InitilizeTap();

            ChooseTimer.Start();
        }

        private void ChooseTimer_Tick(object sender, object e)
        {
            ChooseTarget();
        }

        protected void ChooseTarget()
        {
            if (enemies.Count == 0 || IsOnCooldown())
                return;

            Bloon target = null;

            foreach (var enemy in enemies)
            {
                // Calculate direction to shoot
                int deltaX = enemy.Position.X - Position.X;
                int deltaY = enemy.Position.Y - Position.Y;

                double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

                if (distance <= range)
                {
                    target = enemy;
                    break; // Found a target within range, no need to continue searching
                }
            }

            if (target == null)
                return; // No target within range

            // Calculate the angle in radians
            int deltaXTarget = target.Position.X - Position.X;
            int deltaYTarget = target.Position.Y - Position.Y;
            double angle = Math.Atan2(deltaYTarget, deltaXTarget);
            double angleDegrees = angle * (180.0 / Math.PI);

            // Invert the angle before rotating the image
            RotateImage((float)(-angleDegrees));

            Shoot(angle);

            // Update the last shoot time
            lastShootTime = DateTime.Now;
        }


        private bool IsOnCooldown()
        {
            // Check if the tower is on cooldown based on the last shoot time
            TimeSpan elapsed = DateTime.Now - lastShootTime;
            return elapsed < ShootCooldown;
        }

        private void InitilizeTap()
        {
            image.Tapped += Image_Tapped;
        }

        public void sellTower()
        {
            ChooseTimer.Stop();
            addMoneyForPop((int)(moneySpent * 0.85));
            Undraw();
        }

        protected abstract void UpgradeFirstPath();
        protected abstract void UpgradeSecondPath();
        protected abstract void UpgradeThirdPath();

        public void Upgrade_Tower(Paths path)
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

        private void Image_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            OpenUpgradeMenu(TowerType.Basic, "ms-appx:///Assets/Upgrade_Icons/Sharp_darts.png", "ms-appx:///Assets/Upgrade_Icons/Quick_shots.png", "ms-appx:///Assets/Upgrade_Icons/RangeLol.png", firstPath, secondPath, thirdPath, firstPath_Price, secondPath_Price, thirdPath_Price);
            changeSelectedTower(this);
        }
    }
}