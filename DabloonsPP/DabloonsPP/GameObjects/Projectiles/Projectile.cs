﻿using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    class Projectile : IGameObject
    {
        const int PROJECTILE_WIDTH = 20;
        const int PROJECTILE_HEIGHT = 20;

        public int dx;
        public int dy;

        public int damage;
        protected int pierce;
        protected List<Bloon> enemies;
        
        protected DispatcherTimer Move_Timer;
        protected Dictionary<Bloon, DateTime> lastHitTimes = new Dictionary<Bloon, DateTime>();
        protected TimeSpan cooldownDuration = TimeSpan.FromMilliseconds(150);

        public float Damage
        {
            get { return damage; }
        }

        public int Pierce
        {
            get { return pierce; }
        }

        public Projectile(int x, int y, int dx, int dy, int damage, int pierce, string path, float angle, Canvas canva, List<Bloon> enemies) :
            base(PROJECTILE_WIDTH, PROJECTILE_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;
            this.pierce = pierce;
            this.damage = damage;

            this.enemies = enemies;

            RotateImage(angle);

            Move_Timer = new DispatcherTimer();
            Move_Timer.Interval = TimeSpan.FromTicks(20);
            Move_Timer.Tick += Move_Timer_Tick;

            Move_Timer.Start();
        }

        virtual protected void Move()
        {
            hitbox.setPosition(new System.Drawing.Point(hitbox.getPosition().X + dx, hitbox.getPosition().Y + dy));
        }

        protected void Move_Timer_Tick(object sender, object e)
        {
            Move();
            CheckCollisionWithEnemies();
        }

        virtual protected void CheckCollisionWithEnemies()
        {
            // Assuming enemies is a List<IEnemy> containing all active enemies
            foreach (Bloon enemy in enemies)
            {
                if (MathHelper.CirclesCollide(hitbox, enemy.Hitbox) && !IsOnCooldown(enemy))
                {
                    // Collision detected, apply damage to the enemy
                    enemy.TakeDamage(damage);

                    // Record the time of the last hit for this enemy
                    lastHitTimes[enemy] = DateTime.Now;

                    // Check if projectile has pierce remaining
                    if (--pierce <= 0)
                    {
                        // Projectile has no pierce remaining, remove it
                        RemoveProjectile();
                        return;
                    }
                }
            }
        }

        protected bool IsOnCooldown(Bloon enemy)
        {
            // Check if the enemy is on cooldown based on the last hit time
            if (lastHitTimes.TryGetValue(enemy, out DateTime lastHitTime))
            {
                TimeSpan elapsed = DateTime.Now - lastHitTime;
                return elapsed < cooldownDuration;
            }

            return false; // Not on cooldown if never hit before
        }

        protected void RemoveProjectile()
        {
            // Clear the set of damaged enemies and their last hit times for the next projectile
            lastHitTimes.Clear();

            // Perform any cleanup tasks if needed
            Move_Timer.Stop();
            Undraw();
            // Remove the projectile from the game or set a flag for removal in the main game loop
        }

    }
}
