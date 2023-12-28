using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace DabloonsPP
{
    class IEnemy : IGameObject
    {
        const int ENEMY_HEIGHT = 100;
        const int ENEMY_WIDTH = 125;

        public int dx;
        public int dy;
        public int health;
        
        private Direction direction;
        private Queue<Turn> turns;
        private DispatcherTimer moveTimer;

        #region setters and getters
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }

        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        #endregion

        public IEnemy(int x, int y, string path, Canvas canva, int dx, int dy, int health, Queue<Turn> turns) :
            base(ENEMY_WIDTH, ENEMY_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;
            this.health = health;

            this.turns = turns;

            direction = Direction.Right;

            moveTimer = new DispatcherTimer();
            moveTimer.Interval = TimeSpan.FromMilliseconds(500);
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        private void MovementTurn(Turn turn)
        {
            switch (turn.TurnDirection)
            {
                case Direction.Up:
                    dy *= -1; // Adjust speed for upward movement
                    break;
                case Direction.Down:
                    dy = Math.Abs(dy); // Adjust speed for downward movement
                    break;
                case Direction.Left:
                    dx *= -1; // Adjust speed for leftward movement
                    break;
                case Direction.Right:
                    dx = Math.Abs(dx); // Adjust speed for rightward movement
                    break;
            }
        }

        private void Move(Direction dir)
        {
            if(dir == Direction.Up || dir == Direction.Down)
            {
                hitbox.setPosition(new System.Drawing.Point(hitbox.getPosition().X, hitbox.getPosition().Y + dy));
            }
            else
            {
                hitbox.setPosition(new System.Drawing.Point(hitbox.getPosition().X + dx, hitbox.getPosition().Y));
            }
        }

        private void MoveTimer_Tick(object sender, object e)
        {
            if(turns.Count != 0)
            {
                Turn turn = turns.Peek();

                Ellipse eli = new Ellipse();
                Canvas.SetLeft(eli, hitbox.getPosition().X);
                Canvas.SetTop(eli, hitbox.getPosition().Y);
                GameCanvas.Children.Add(eli);
                if (MathHelper.CirclesCollide(hitbox, turn.Hitbox))
                {
                    direction = turn.TurnDirection;
                    MovementTurn(turn);
                    turn = turns.Dequeue();
                }

                GameCanvas.Children.Remove(eli);
            }

            Move(direction);
            Draw();
        }
    }
}
