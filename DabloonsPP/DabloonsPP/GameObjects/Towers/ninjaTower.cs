using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace DabloonsPP.GameObjects.Towers
{
    internal class NinjaTower : ITower
    {
        private int projectile_speed = 50;
        private int pierce = 2;
        private static int width = 75;
        private static int height = 75;
        private DispatcherTimer ChooseTimer;
        public NinjaTower(int x, int y, Canvas canva, int damage, List<Bloon> enemies) :
            base(width, height, (x - (width / 2)), (y - (height / 2)), "Monkeys\\ninja_monkey.png", canva, damage, 250, enemies, TimeSpan.FromMilliseconds(550))
        {
            ChooseTimer = new DispatcherTimer();
            ChooseTimer.Interval = TimeSpan.FromTicks(20);
            ChooseTimer.Tick += ChooseTimer_Tick;

            ChooseTimer.Start();
        }

        private void ChooseTimer_Tick(object sender, object e)
        {
            ChooseTarget();
        }

        protected override void Shoot(double angle)
        {
            // Calculate the velocity components
            double speed = projectile_speed;
            int vx = (int)(speed * Math.Cos(angle));
            int vy = (int)(speed * Math.Sin(angle));

            Projectile projectile = new Projectile(Position.X, Position.Y, vx, vy, damage, pierce, "Projectiles\\shurikan.png", (float)angle, GameCanvas, enemies);
        }
    }
}
