using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace DabloonsPP.HelperClasses
{
    public static class MathHelper
    {
        public static bool CirclesCollide(MyCircle circle1, MyCircle circle2)
        {
            float disX = Math.Abs(circle1.getPosition().X - circle2.getPosition().X);
            float disY = Math.Abs(circle1.getPosition().Y - circle2.getPosition().Y);

            float distance = (float)Math.Sqrt((disX*disX) + (disY*disY));

            float radSum = (float)(circle1.getCircle().Width + circle2.getCircle().Width);

            return distance < radSum;
        }

        public static double Distance(Point p1, Point p2)
        {
            int deltaX = p2.X - p1.X;
            int deltaY = p2.Y - p1.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
