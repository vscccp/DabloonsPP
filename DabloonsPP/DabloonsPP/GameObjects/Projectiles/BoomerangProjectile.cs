using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabloonsPP.GameObjects.Projectiles
{
    using global::DabloonsPP.HelperClasses;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows;
    using Windows.UI.Xaml.Controls;

    namespace DabloonsPP
    {
        internal class BoomerangProjectile : Projectile
        {
            private Point originalPosition;
            private bool returning = false;
            private int returnSpeed = 10; // Adjust the return speed as needed

            public BoomerangProjectile(int x, int y, int dx, int dy, int damage, int pierce, string path, float angle, Canvas canva, List<Bloon> enemies)
                : base(x, y, dx, dy, damage, pierce, path, angle, canva, enemies)
            {
                originalPosition = new Point(x, y);
            }

            protected override void Move()
            {
                if (!returning)
                    base.Move();
                else
                {
                    // Move back to the original position
                    hitbox.setPosition(new System.Drawing.Point(hitbox.getPosition().X - returnSpeed, hitbox.getPosition().Y));

                    // Check if the projectile returned to the starting position
                    if (MathHelper.Distance(hitbox.getPosition(), new System.Drawing.Point((int)originalPosition.X, (int)originalPosition.Y)) <= returnSpeed)
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
                    }
                }
            }
        }
    }
}
