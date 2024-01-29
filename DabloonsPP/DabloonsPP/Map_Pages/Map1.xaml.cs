﻿using DabloonsPP.GameObjects.Towers;
using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

        private List<Bloon> enemies = new List<Bloon>();
        public Queue<Turn> turns = new Queue<Turn>();
        private DispatcherTimer enemyCheckTimer;
        private Border selectedTower;
        uint round = 1;

        #region Stats

        private int money = 850;
        private int health = 100;

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

            #region enemyCheckTimer init
            // Initialize and start the timer for checking enemies' health
            enemyCheckTimer = new DispatcherTimer();
            enemyCheckTimer.Interval = TimeSpan.FromMilliseconds(500); // Adjust the interval as needed
            enemyCheckTimer.Tick += EnemyCheckTimer_Tick;
            enemyCheckTimer.Start();
            #endregion

            selectedTower = null;

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.W)
            {
                Bloon enemy = new Bloon(STARTING_X, STARTING_Y, GameCanva, 1, turns, Reduce_Health);

                enemies.Add(enemy);
            }
            else if(args.VirtualKey == Windows.System.VirtualKey.S)
            {
                Bloon enemy = new Bloon(STARTING_X, STARTING_Y, GameCanva, 5, turns, Reduce_Health);

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
                else if (enemies[i].Turns.Count() == 0)
                {
                    enemies.RemoveAt(i);
                }
            }
        }

        private void Tower_Selected(object sender, TappedRoutedEventArgs e)
        {
            // Deselect previously selected tower (if any)
            if (selectedTower != null)
            {
                // Reset the border thickness
                selectedTower.BorderThickness = new Thickness(0);
            }

            // Select the clicked tower
            selectedTower = sender as Border;
            selectedTower.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            selectedTower.BorderThickness = new Thickness(5);
        }

        private void GameCanva_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (selectedTower != null)
            {
                // Get the position of the tap relative to the Canvas
                Point tapPosition = e.GetPosition(GameCanva);

                // Retrieve X and Y coordinates
                int tapX = (int)tapPosition.X;
                int tapY = (int)tapPosition.Y;

                // Use the selected tower's Tag to identify the chosen tower
                string towerType = selectedTower.Tag as string;

                if(towerType == "dart_monkey")
                {
                    // Create the tower based on the selected color
                    BasicTower newTower = new BasicTower(tapX, tapY, GameCanva, 1, enemies);
                }
                else if(towerType == "ninja_monkey")
                {
                    NinjaTower newTower = new NinjaTower(tapX, tapY, GameCanva, 1, enemies);
                }
                else if(towerType == "super_monkey")
                {
                    SuperTower newTower = new SuperTower(tapX, tapY, GameCanva, 1, enemies);
                }
                else if(towerType == "boomerang_monkey")
                {
                    BoomerangTower newTower = new BoomerangTower(tapX, tapY, GameCanva, 1, enemies);
                }
                // Deselect the tower after placing it
                selectedTower.BorderThickness = new Thickness(0);
                selectedTower = null;
            }
        }

        private void Reduce_Health(int health_reduce)
        {
            health -= health_reduce;

            health_block.Text = health.ToString();
            if(health <= 0)
            {
                // implement lose screen and statistics
            }
        }
    }
}
