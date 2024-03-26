using DabloonsPP.Assets.Menu_Pages;
using DabloonsPP.GameObjects.Towers;
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
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DabloonsPP.Map_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class map2 : Page
    {
        #region constants
        const int STARTING_X = -50;
        const int STARTING_Y = 250;
        #endregion

        MediaElement moneySound = new MediaElement();
        private List<Bloon> enemies = new List<Bloon>();
        public Queue<Turn> turns = new Queue<Turn>();
        private DispatcherTimer enemyCheckTimer;
        private ITower selectedTower;
        private Border selectedTower_icon;
        GameData gameData;

        private RoundManager roundManager;

        #region Stats

        private int money = 850;
        private int health = 100;
        private int TotalMoneySpent = 0;
        private int totalAccumuleted = 0;
        private int towersBuilt = 0;
        private TimeSpan gameTime;
        private DateTime gameTimeStart;

        #endregion
        public map2()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            #region Initialize Turns
            
            #endregion

            #region enemyCheckTimer init
            // Initialize and start the timer for checking enemies' health
            enemyCheckTimer = new DispatcherTimer();
            enemyCheckTimer.Interval = TimeSpan.FromMilliseconds(500); // Adjust the interval as needed
            enemyCheckTimer.Tick += EnemyCheckTimer_Tick;
            enemyCheckTimer.Start();
            #endregion

            gameTimeStart = DateTime.Now;

            selectedTower_icon = null;

            moneySound.Source = new Uri("ms-appx:///Assets/SFX/moneySound.mp3");
            moneySound.AutoPlay = false;
            GameCanva.Children.Add(moneySound);
            roundManager = new RoundManager(GameCanva, addMoneyForPop, enemies, STARTING_X, STARTING_Y, turns, Reduce_Health, round_block);

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null && e.Parameter is GameData)
            {
                GameData receivedData = (GameData)e.Parameter;
                money += receivedData.MoneyTiers * 50;
                health += receivedData.HealthTiers * 5;
            }
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.W)
            {
                Bloon enemy = new Bloon(STARTING_X, STARTING_Y, GameCanva, 1, turns, addMoneyForPop, Reduce_Health, false, 0);

                enemies.Add(enemy);
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.S)
            {
                Bloon enemy = new Bloon(STARTING_X, STARTING_Y, GameCanva, 5, turns, addMoneyForPop, Reduce_Health, false, 0);

                enemies.Add(enemy);
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.M)
            {
                money += 200;
                money_block.Text = money.ToString();

                moneySound.Play();
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
            if (selectedTower_icon != null)
            {
                // Reset the border thickness
                selectedTower_icon.BorderThickness = new Thickness(0);
            }

            // Select the clicked tower
            selectedTower_icon = sender as Border;
            selectedTower_icon.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            selectedTower_icon.BorderThickness = new Thickness(5);
        }

        private void GameCanva_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (selectedTower_icon != null)
            {
                // Get the position of the tap relative to the Canvas
                Point tapPosition = e.GetPosition(GameCanva);

                // Retrieve X and Y coordinates
                int tapX = (int)tapPosition.X;
                int tapY = (int)tapPosition.Y;

                // Use the selected tower's Tag to identify the chosen tower
                string towerType = selectedTower_icon.Tag as string;

                if (towerType == "dart_monkey" && TryReduceMoney((int)BasicTower_Prices.TowerPrice))
                {
                    // Create the tower based on the selected color
                    BasicTower newTower = new BasicTower(tapX, tapY, GameCanva, 1, enemies, TryReduceMoney, changeMenu, changeSelectedTower, addMoneyForPop);
                    towersBuilt++;
                }
                else if (towerType == "ninja_monkey" && TryReduceMoney((int)NinjaTower_Prices.TowerPrice))
                {
                    NinjaTower newTower = new NinjaTower(tapX, tapY, GameCanva, 1, enemies, TryReduceMoney, changeMenu, changeSelectedTower, addMoneyForPop);
                    towersBuilt++;
                }
                else if (towerType == "super_monkey" && TryReduceMoney((int)SuperTower_Prices.TowerPrice))
                {
                    SuperTower newTower = new SuperTower(tapX, tapY, GameCanva, 1, enemies, TryReduceMoney, changeMenu, changeSelectedTower, addMoneyForPop);
                    towersBuilt++;
                }
                else if (towerType == "boomerang_monkey" && TryReduceMoney((int)BoomerangTower_Prices.TowerPrice))
                {
                    BoomerangTower newTower = new BoomerangTower(tapX, tapY, GameCanva, 1, enemies, TryReduceMoney, changeMenu, changeSelectedTower, addMoneyForPop);
                    towersBuilt++;
                }
                // Deselect the tower after placing it
                selectedTower_icon.BorderThickness = new Thickness(0);
                selectedTower_icon = null;
            }
        }

        private void changeSelectedTower(ITower tower)
        {
            selectedTower = tower;
        }

        private void changeMenu(TowerType tower, string PhotoPath1, string PhotoPath2, string PhotoPath3, int firstPath, int secondPath, int thirdPath, int price1, int price2, int price3)
        {
            if (upgradeMenu.Visibility == Visibility.Collapsed)
            {
                TowersRight.Visibility = Visibility.Collapsed;
                TowersLeft.Visibility = Visibility.Collapsed;
                PlayButton.Visibility = Visibility.Collapsed;

                upgradeMenu.Visibility = Visibility.Visible;

                // Change tower name and image source based on tower type
                switch (tower)
                {
                    case TowerType.Basic:
                        TowerName.Text = "Basic Tower";
                        // Change image source for upgrade1, upgrade2, upgrade3
                        // For example:
                        upgrade1.Source = new BitmapImage(new Uri(PhotoPath1));
                        upgrade2.Source = new BitmapImage(new Uri(PhotoPath2));
                        upgrade3.Source = new BitmapImage(new Uri(PhotoPath3));
                        break;
                    case TowerType.ninja:
                        TowerName.Text = "Ninja Monkey";
                        // Change image source for upgrade1, upgrade2, upgrade3
                        break;
                    case TowerType.super:
                        TowerName.Text = "Super Monkey";
                        // Change image source for upgrade1, upgrade2, upgrade3
                        break;
                    case TowerType.boomerang:
                        TowerName.Text = "Boomerang Monkey";
                        // Change image source for upgrade1, upgrade2, upgrade3
                        break;
                }

                // Color the rectangles green based on the path
                ColorRectangles(upgrade1_1, upgrade1_2, upgrade1_3, firstPath);
                ColorRectangles(upgrade2_1, upgrade2_2, upgrade2_3, secondPath);
                ColorRectangles(upgrade3_1, upgrade3_2, upgrade3_3, thirdPath);

                // Change button prices
                upgrade1_buy.Content = $"{price1}$";
                upgrade2_buy.Content = $"{price2}$";
                upgrade3_buy.Content = $"{price3}$";
            }
            else
            {
                TowersRight.Visibility = Visibility.Visible;
                TowersLeft.Visibility = Visibility.Visible;
                PlayButton.Visibility = Visibility.Visible;

                upgradeMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void addMoneyForPop(int pops)
        {
            money += pops;
            money_block.Text = money.ToString();
            totalAccumuleted += pops;
        }

        private void ColorRectangles(Rectangle rect1, Rectangle rect2, Rectangle rect3, int path)
        {
            // Set all rectangles to gray first
            rect1.Fill = rect2.Fill = rect3.Fill = new SolidColorBrush(Colors.Gray);

            // Color the rectangles green based on the path
            if (path >= 1 && path <= 3)
            {
                switch (path)
                {
                    case 1:
                        rect1.Fill = new SolidColorBrush(Colors.Green);
                        break;
                    case 2:
                        rect1.Fill = rect2.Fill = new SolidColorBrush(Colors.Green);
                        break;
                    case 3:
                        rect1.Fill = rect2.Fill = rect3.Fill = new SolidColorBrush(Colors.Green);
                        break;
                }
            }
        }



        private void Reduce_Health(int health_reduce)
        {
            health -= health_reduce;

            health_block.Text = health.ToString();
            if (health <= 0)
            {
                // implement lose screen and statistics
            }
        }

        private bool TryReduceMoney(int moneyReduced)
        {
            if (money >= moneyReduced)
            {
                money -= moneyReduced;
                money_block.Text = money.ToString();
                TotalMoneySpent += moneyReduced;
                return true;
            }

            return false;
        }

        private void Sell_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (upgradeMenu.Visibility == Visibility.Collapsed)
                return;

            selectedTower.sellTower();

            TowersRight.Visibility = Visibility.Visible;
            TowersLeft.Visibility = Visibility.Visible;
            PlayButton.Visibility = Visibility.Visible;

            upgradeMenu.Visibility = Visibility.Collapsed;
        }

        private void upgrade_buy_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            Paths path;
            if ((string)butt.Tag == "Path1")
            {
                path = Paths.FirstPath;
                if (selectedTower.FirstPath == 3)
                    return;
            }
            else if ((string)butt.Tag == "Path2")
            {
                path = Paths.SecondPath;
                if (selectedTower.SecondPath == 3)
                    return;
            }
            else
            {
                path = Paths.ThirdPath;
                if (selectedTower.ThirdPath == 3)
                    return;
            }
            selectedTower.Upgrade_Tower(path);

            // After upgrading, update the UI to reflect the new upgrade path
            int firstPath = selectedTower.FirstPath;
            int secondPath = selectedTower.SecondPath;
            int thirdPath = selectedTower.ThirdPath;

            // Color the rectangles green based on the updated path
            ColorRectangles(upgrade1_1, upgrade1_2, upgrade1_3, firstPath);
            ColorRectangles(upgrade2_1, upgrade2_2, upgrade2_3, secondPath);
            ColorRectangles(upgrade3_1, upgrade3_2, upgrade3_3, thirdPath);

            // Change button prices
            upgrade1_buy.Content = $"{selectedTower.FirstPath_Price}$";
            upgrade2_buy.Content = $"{selectedTower.SecondPath_Price}$";
            upgrade3_buy.Content = $"{selectedTower.ThirdPath_Price}$";
        }

        private void PlayButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            roundManager.startRound();
        }
    }
}
