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

        protected List<IEnemy> enemies;
        protected abstract void Shoot(double angle);



        public ITower(int width, int height, int x, int y, string path, Canvas canva, int damage, float range, List<IEnemy> enemeies) : base(width, height, x, y, path, canva)
        {
            this.damage = damage;
            this.range = range;
            this.enemies = enemeies;
        }

        protected void ChooseTarget()
        {
            if (enemies.Count == 0)
                return;

            IEnemy target = enemies.First();

            // Calculate direction to shoot
            int deltaX = target.Position.X - Position.X; // Corrected order of subtraction
            int deltaY = target.Position.Y - Position.Y; // Corrected order of subtraction

            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            if (distance > range)
                return;

            // Calculate the angle in radians
            double angle = Math.Atan2(deltaY, deltaX); // Corrected order of parameters
            double angleDegrees = angle * (180.0 / Math.PI);

            Debug.WriteLine(angleDegrees);
            RotateImage((float)(angleDegrees-90));

            Shoot(angle);
        }

    }
}
