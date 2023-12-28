using System;
using System.Collections.Generic;
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

        public Turn(MyCircle hitbox, Direction direction)
        {
            Hitbox = hitbox;
            TurnDirection = direction;
        }
    }
}
