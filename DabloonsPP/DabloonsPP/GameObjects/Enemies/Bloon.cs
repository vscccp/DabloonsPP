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
    enum Bloon_Colors
    {
        RED = 1,
        BLUE = 2,
        GREEN = 3,
        YELLOW = 4,
        PINK = 5,
        LEAD = 6
    }


    delegate void reduceHealth(int healthReduced);

    class Bloon : IGameObject
    {

        const int ENEMY_HEIGHT = 75;
        const int ENEMY_WIDTH = 75;

        public int dx;
        public int dy;
        public int health;
        
        private Direction direction;
        private Queue<Turn> turns;
        private DispatcherTimer moveTimer;

        private bool isCamo;
        private int ceramicLayers;

        private reduceHealth reduceHealth;

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

        public Queue<Turn> Turns
        {
            get { return turns; }
        }

        #endregion

        public Bloon(int x, int y, Canvas canva, int health, Queue<Turn> turns, reduceHealth reduceHealth, bool isCamo, int ceramicLayers) :
            base(ENEMY_WIDTH, ENEMY_HEIGHT, x, y, canva)
        {
            this.health = health;
            this.turns = new Queue<Turn>(turns);

            direction = Direction.RIGHT;

            SetSpeed();

            moveTimer = new DispatcherTimer();
            moveTimer.Interval = TimeSpan.FromMilliseconds(50);
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();

            SetBloonImage((Bloon_Colors)health);
            this.reduceHealth = reduceHealth;
            this.isCamo = isCamo;
            this.ceramicLayers = ceramicLayers;
        }

        private void Move(Direction dir)
        {
            if(dir == Direction.UP || dir == Direction.DOWN)
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
                if (MathHelper.CirclesCollide(hitbox, turn.Hitbox)) // if collides
                {
                    direction = turn.TurnDirection;
                    SetSpeed();
                    turn = turns.Dequeue();

                    if (turns.Count == 0) // if finished map then remove
                    {
                        this.Undraw();
                        moveTimer.Stop();
                        reduceHealth(health);
                        return;
                    }
                }
            }

            Move(direction);
            Draw();
        }

        private void SetSpeed()
        {
            int speed = 0;
            switch ((Bloon_Colors)health)
            {
                case Bloon_Colors.PINK:
                    speed = 40;
                    break;
                case Bloon_Colors.YELLOW:
                    speed = 30;
                    break;
                case Bloon_Colors.GREEN:
                    speed = 20;
                    break;
                case Bloon_Colors.BLUE:
                    speed = 15;
                    break;
                default:
                    speed = 10;
                    break;
                    
            }
            switch (direction)
            {
                case Direction.UP:
                    dy = speed * -1;
                    dx = 0;
                    break;
                case Direction.DOWN:
                    dy = speed;
                    dx = 0;
                    break;
                case Direction.LEFT:
                    dx = speed * -1;
                    dy = 0;
                    break;
                case Direction.RIGHT:
                    dx = speed;
                    dy = 0;
                    break;
            }
        }

        private void SetBloonImage(Bloon_Colors bloonColor)
        {
            switch (bloonColor)
            {
                case Bloon_Colors.RED:
                    SetImage("Enemies\\bloon.png", 50, 50);
                    break;
                case Bloon_Colors.BLUE:
                    SetImage("Enemies\\bloonBlue.png", 50, 50);
                    break;
                case Bloon_Colors.GREEN:
                    SetImage("Enemies\\bloonGreen.png", 50, 50);
                    break;
                case Bloon_Colors.YELLOW:
                    SetImage("Enemies\\bloonYellow.png", 50, 50);
                    break;
                case Bloon_Colors.PINK:
                    SetImage("Enemies\\bloonPink.png", 50, 50);
                    break;
            }
        }

        public async void TakeDamage(int damage, bool shootsCamo, bool shootsLead)
        {
            health -= damage;

            if (health <= 0)
            {
                SetImage("VFX\\pop.png", 50, 50);
                moveTimer.Stop();

                // Wait for 1 second (1000 milliseconds)
                await Task.Delay(500);

                Undraw();
            }
            else
            {
                Bloon_Colors bloonColor = (Bloon_Colors)health;
                SetBloonImage(bloonColor);
                SetSpeed();
            }
        }

    }
}
