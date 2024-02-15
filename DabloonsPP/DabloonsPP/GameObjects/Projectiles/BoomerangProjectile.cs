using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    internal class BoomerangProjectile : Projectile
    {
        private Point originalPosition;
        private bool returning = false;
        private float range; // Added range field
        private int rotationAngle = 0;

        public BoomerangProjectile(int x, int y, int dx, int dy, int damage, int pierce, float range, string path, float angle, Canvas canva, List<Bloon> enemies, AddMoneyForPop addMoneyForPop, bool shootsCamo, bool shootsLead)
            : base(x, y, dx, dy, damage, pierce, path, angle, canva, enemies, addMoneyForPop, shootsCamo, shootsLead)
        {
            originalPosition = new Point(x, y);
            this.range = range;
        }

        protected override void Move()
        {
            if(rotationAngle >= 360)
            {
                rotationAngle -= 360;
            }
            rotationAngle += 150;
            RotateImage(rotationAngle);
            if (!returning)
            {
                base.Move();

                // Check if the boomerang has traveled beyond the specified range
                if (MathHelper.Distance(hitbox.getPosition(), new System.Drawing.Point((int)originalPosition.X, (int)originalPosition.Y)) >= range)
                {
                    returning = true;
                    dx *= -1;
                    dy *= -1;
                }
            }
            else
            {
                // Move back to the original position
                base.Move();

                // Check if the projectile returned to the starting position
                if (MathHelper.Distance(hitbox.getPosition(), new System.Drawing.Point((int)originalPosition.X, (int)originalPosition.Y)) <= 25)
                {
                    RemoveProjectile();
                }
            }
        }

        protected override void CheckCollisionWithEnemies()
        {
            if (!returning)
            {
                base.CheckCollisionWithEnemies();

                // Check if the projectile needs to start returning
                if (pierce <= 0)
                {
                    returning = true;
                    dx *= -1;
                    dy *= -1;
                }
            }
        }
    }
}
