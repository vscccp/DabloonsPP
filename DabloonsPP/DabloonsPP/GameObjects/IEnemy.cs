using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP
{
    class IEnemy : IGameObject
    {
        const int ENEMY_HEIGHT = 100;
        const int ENEMY_WIDTH = 125;

        public int dx;
        public int dy;
        public int health;
        List<Turn> turns;

        private DispatcherTimer moveTimer;
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

        public IEnemy(int x, int y, string path, Canvas canva, int dx, int dy, int health, List<Turn> turns) :
            base(ENEMY_WIDTH, ENEMY_HEIGHT, x, y, path, canva)
        {
            this.dx = dx;
            this.dy = dy;
            this.health = health;

            this.turns = turns;

            moveTimer = new DispatcherTimer();
            moveTimer.Interval = TimeSpan.FromTicks(20);
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        public void CheckIntersectionWithTurns(List<Turn> turns)
        {
            foreach (Turn turn in turns)
            {
                Point enemyCenter = new Point(position.X, position.Y);
                Point turnCenter = new Point(Canvas.GetLeft(turn.Hitbox), Canvas.GetTop(turn.Hitbox));

                double enemyRadius = hitbox.Width / 2;
                double turnRadius = turn.Hitbox.Width / 2;

                double distance = Math.Sqrt(Math.Pow(turnCenter.X - enemyCenter.X, 2) + Math.Pow(turnCenter.Y - enemyCenter.Y, 2));

                // Check for intersection by comparing distances
                if (distance <= enemyRadius + turnRadius)
                {
                    // Intersection detected with a turn, update speed based on the turn direction
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
                    break; // Exit loop after handling intersection with a turn
                }
            }
        }

        private void MoveTimer_Tick(object sender, object e)
        {
            position.X += dx;
            position.Y += dy;



            Draw();
        }
    }
}
