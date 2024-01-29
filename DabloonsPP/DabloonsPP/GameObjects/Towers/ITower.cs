using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    abstract class ITower : IGameObject
    {
        public int damage { get; set; }
        public float range { get; set; }

        protected List<Bloon> enemies;
        protected abstract void Shoot(double angle);



        public ITower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<Bloon> enemeies) : base(width, height, x, y, path, canva)
        {
            this.damage = damage;
            this.range = range;
            this.enemies = enemeies;
        }

        protected void ChooseTarget()
        {
            if (enemies.Count == 0)
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
        }


    }
}
