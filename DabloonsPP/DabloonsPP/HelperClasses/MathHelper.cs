using System;
using System.Collections.Generic;
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
    }
}
