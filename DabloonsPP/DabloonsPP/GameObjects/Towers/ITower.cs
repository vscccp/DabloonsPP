using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    abstract class ITower : IGameObject
    {
        public int damage { get; set; }
        public float range { get; set; }
        public TimeSpan ShootCooldown { get; set; }

        protected List<Bloon> enemies;
        private DateTime lastShootTime = DateTime.MinValue;
        private DispatcherTimer ChooseTimer;

        protected abstract void Shoot(double angle);

        public ITower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<Bloon> enemies, TimeSpan shootCooldown)
            : base(width, height, x, y, path, canva)
        {
            this.damage = damage;
            this.range = range;
            this.enemies = enemies;
            this.ShootCooldown = shootCooldown;

            ChooseTimer = new DispatcherTimer();
            ChooseTimer.Interval = TimeSpan.FromTicks(20);
            ChooseTimer.Tick += ChooseTimer_Tick;

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

            Bloon target = enemies.First();

            // Calculate direction to shoot
            int deltaX = target.Position.X - Position.X;
            int deltaY = target.Position.Y - Position.Y;

            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            if (distance > range)
                return;

            // Calculate the angle in radians
            double angle = Math.Atan2(deltaY, deltaX);
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
    }
}