using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace DabloonsPP.HelperClasses
{
    public enum Direction
    {
        RIGHT = 0,
        LEFT = 1,
        UP = 2,
        DOWN = 3,
        UP_LEFT = 4,
        UP_RIGHT = 5,
        DOWN_LEFT = 6,
        DOWN_RIGHT = 7
    };
    public class Turn
    {
        public MyCircle Hitbox { get; set; }
        public Direction TurnDirection { get; set; }

        public Turn(Ellipse hitbox ,Point pos , Direction direction)
        {
            Hitbox = new MyCircle(pos ,hitbox);
            TurnDirection = direction;
        }
    }
}
