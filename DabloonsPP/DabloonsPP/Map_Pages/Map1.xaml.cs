using DabloonsPP.GameObjects.Towers;
using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DabloonsPP
{
    
    public sealed partial class Map1 : Page
    {
        #region constants
        const int STARTING_X = -50;
        const int STARTING_Y = 250;
        #endregion

        private List<IEnemy> enemies = new List<IEnemy>();
        public Queue<Turn> turns = new Queue<Turn>();
        private DispatcherTimer enemyCheckTimer;
        uint round = 1;

        #region Stats

        int money = 850;
        int hearts = 100;

        #endregion
        public Map1()
        {
            this.InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            #region Initialize Turns
            turns.Enqueue(new Turn(turn1, new System.Drawing.Point((int)Canvas.GetLeft(turn1), (int)Canvas.GetTop(turn1)), Direction.DOWN));
            turns.Enqueue(new Turn(turn2, new System.Drawing.Point((int)Canvas.GetLeft(turn2), (int)Canvas.GetTop(turn2)), Direction.RIGHT));
            turns.Enqueue(new Turn(turn3, new System.Drawing.Point((int)Canvas.GetLeft(turn3), (int)Canvas.GetTop(turn3)), Direction.UP));
            turns.Enqueue(new Turn(turn4, new System.Drawing.Point((int)Canvas.GetLeft(turn4), (int)Canvas.GetTop(turn4)), Direction.RIGHT));
            turns.Enqueue(new Turn(turn5, new System.Drawing.Point((int)Canvas.GetLeft(turn5), (int)Canvas.GetTop(turn5)), Direction.DOWN));
            turns.Enqueue(new Turn(end, new System.Drawing.Point((int)Canvas.GetLeft(end), (int)Canvas.GetTop(end)), Direction.DOWN));
            #endregion

            // Initialize and start the timer for checking enemies' health
            enemyCheckTimer = new DispatcherTimer();
            enemyCheckTimer.Interval = TimeSpan.FromMilliseconds(500); // Adjust the interval as needed
            enemyCheckTimer.Tick += EnemyCheckTimer_Tick;
            enemyCheckTimer.Start();

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown; ;
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.W)
            {
                IEnemy enemy = new IEnemy(STARTING_X, STARTING_Y, "\\enemies\\bloon.png", GameCanva, 20, 20, 1, turns);

                enemies.Add(enemy);
            }
        }

        private void EnemyCheckTimer_Tick(object sender, object e)
        {
            // Iterate through the list of enemies and remove those with health <= 0
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].Health <= 0)
                {
                    enemies.RemoveAt(i);
                }
            }
        }


        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            // Get the position of the tap relative to the Image control
            Point tapPosition = e.GetPosition(sender as UIElement);

            // Retrieve X and Y coordinates
            int tapX = (int)(tapPosition.X);
            int tapY = (int)(tapPosition.Y);

            BasicTower test = new BasicTower(tapX, tapY, "Monkeys\\Dart_Monkey.png", GameCanva, 1, enemies);
        }
    }
}
