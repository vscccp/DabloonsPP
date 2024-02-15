using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email.DataProvider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DabloonsPP.HelperClasses
{
    class RoundManager
    {
        private Canvas gameCanva;
        private int round = 1;
        private List<Bloon> enemies;
        private Queue<Turn> turns;

        TextBlock roundBlock;

        private int STARTING_X;
        private int STARTING_Y;

        private DispatcherTimer enemyChecker;

        private AddMoneyForPop addMoney;
        private reduceHealth reduceHealth;

        public RoundManager(Canvas gameCanvas, AddMoneyForPop addMoney, List<Bloon> enemies, int startX, int startY, Queue<Turn> turns, reduceHealth reduceHealth, TextBlock roundBlock)
        {
            this.gameCanva = gameCanvas;
            this.addMoney = addMoney;
            this.enemies = enemies;
            this.turns = turns;
            this.reduceHealth = reduceHealth;

            enemyChecker = new DispatcherTimer();
            enemyChecker.Tick += EnemyChecker_Tick;
            enemyChecker.Interval = TimeSpan.FromSeconds(1);

            STARTING_X = startX;
            STARTING_Y = startY;
            this.roundBlock = roundBlock;
        }

        private void EnemyChecker_Tick(object sender, object e)
        {
            if (enemies.Count == 0)
            {
                addMoney(100+round);
                round++;
                roundBlock.Text = "Round: " + round.ToString(); 
                enemyChecker.Stop();
            }
        }

        public async void startRound()
        {
            switch (round)
            {
                case 1:
                    //red bloons
                    for (int i = 0; i < 20; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(555);
                    }
                    break;

                case 2:
                    //red bloons
                    for (int i = 0; i < 35; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(455);
                    }
                    break;
                case 3:
                    //red bloons
                    for (int i = 0; i < 25; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(455);
                    }

                    await Task.Delay(1000); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 5; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(555);
                    }
                    break;
                case 4:
                    //red bloons
                    for (int i = 0; i < 35; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(355);
                    }

                    await Task.Delay(900); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 18; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }
                    break;
                case 5:
                    //red bloons
                    for (int i = 0; i < 5; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(155);
                    }

                    await Task.Delay(900); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 27; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }
                    break;
                case 6:
                    //red bloons
                    for (int i = 0; i < 15; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }

                    await Task.Delay(900); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 15; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }

                    await Task.Delay(900); // delay between colors
                    //green bloons
                    for (int i = 0; i < 4; i++)
                    {
                        int health = 3;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(155);
                    }
                    break;
                case 7:
                    //red bloons
                    for (int i = 0; i < 20; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(355);
                    }

                    await Task.Delay(900); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 20; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }

                    await Task.Delay(900); // delay between colors
                    //green bloons
                    for (int i = 0; i < 5; i++)
                    {
                        int health = 3;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }
                    break;
                case 8:
                    //red bloons
                    for (int i = 0; i < 10; i++)
                    {
                        int health = 1;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(355);
                    }

                    await Task.Delay(900); // delay between colors
                    //blue bloons
                    for (int i = 0; i < 20; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }

                    await Task.Delay(900); // delay between colors
                    //green bloons
                    for (int i = 0; i < 14; i++)
                    {
                        int health = 3;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(255);
                    }
                    break;
                case 9:
                    //green bloons
                    for (int i = 0; i < 30; i++)
                    {
                        int health = 3;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(300);
                    }
                    break;
                case 10:
                    //blue bloons
                    for (int i = 0; i < 102; i++)
                    {
                        int health = 2;
                        bool isCamo = false;
                        int ceramicLayers = 0;
                        Bloon enemy = new Bloon(STARTING_X, STARTING_Y, gameCanva, health, turns, addMoney, reduceHealth, isCamo, ceramicLayers);

                        enemies.Add(enemy);

                        await Task.Delay(400);
                    }
                    break;
            }

            enemyChecker.Start();
        }

        
    }
}
