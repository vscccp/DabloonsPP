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
        Up,
        Down,
        Left,
        Right
    }
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
