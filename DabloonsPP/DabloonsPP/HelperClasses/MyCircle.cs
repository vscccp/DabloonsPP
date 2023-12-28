using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace DabloonsPP.HelperClasses
{
    public class MyCircle
    {
        private Point position;
        private Ellipse circle;

        public MyCircle(Point position, Ellipse circle)
        {
            this.position = position;
            this.circle = circle;
        }

        // Getter for position
        public Point getPosition()
        {
            return position;
        }

        // Setter for position
        public void setPosition(Point position)
        {
            this.position = position;
        }

        // Getter for circle
        public Ellipse getCircle()
        {
            return circle;
        }

        // Setter for circle
        public void setCircle(Ellipse circle)
        {
            this.circle = circle;
        }
    }
}
