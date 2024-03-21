using DabloonsPP.Assets.Menu_Pages;
using DabloonsPP.DabloonsDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

enum HealthUpgrade_Prices { 
    tier1 = 150,
    tier2 = 300,
    tier3 = 600,
    tier4 = 800
};

enum MoneyUpgrade_Prices
{
    tier1 = 200,
    tier2 = 400,
    tier3 = 800,
    tier4 = 1000
};

namespace DabloonsPP.Menu_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BloonShop : Page
    {
        DabloonsDB.Unlocked unlocked;
        DabloonsDB.IService1 service1;
        public BloonShop()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button chicken_butt = (Button)sender;
            bool changed = false;
            if(chicken_butt.Tag == "health")
            {
                switch (unlocked.HealthTiers)
                {
                    case 0:
                        if(unlocked.GameCurrency >= (int)HealthUpgrade_Prices.tier1)
                        {
                            unlocked.GameCurrency -= (int)HealthUpgrade_Prices.tier1;
                            unlocked.HealthTiers++;
                            changed = true;
                        }
                        break;
                    case 1:
                        if (unlocked.GameCurrency >= (int)HealthUpgrade_Prices.tier2)
                        {
                            unlocked.GameCurrency -= (int)HealthUpgrade_Prices.tier2;
                            unlocked.HealthTiers++;
                            changed = true;
                        }
                        break;
                    case 2:
                        if (unlocked.GameCurrency >= (int)HealthUpgrade_Prices.tier3)
                        {
                            unlocked.GameCurrency -= (int)HealthUpgrade_Prices.tier3;
                            unlocked.HealthTiers++;
                            changed = true;
                        }
                        break;
                    case 3:
                        if (unlocked.GameCurrency >= (int)HealthUpgrade_Prices.tier4)
                        {
                            unlocked.GameCurrency -= (int)HealthUpgrade_Prices.tier4;
                            unlocked.HealthTiers++;
                            changed = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (unlocked.MoneyTiers)
                {
                    case 0:
                        if (unlocked.GameCurrency >= (int)MoneyUpgrade_Prices.tier1)
                        {
                            unlocked.GameCurrency -= (int)MoneyUpgrade_Prices.tier1;
                            unlocked.MoneyTiers++;
                            changed = true;
                        }
                        break;
                    case 1:
                        if (unlocked.GameCurrency >= (int)MoneyUpgrade_Prices.tier2)
                        {
                            unlocked.GameCurrency -= (int)MoneyUpgrade_Prices.tier2;
                            unlocked.MoneyTiers++;
                            changed = true;
                        }
                        break;
                    case 2:
                        if (unlocked.GameCurrency >= (int)MoneyUpgrade_Prices.tier3)
                        {
                            unlocked.GameCurrency -= (int)MoneyUpgrade_Prices.tier3;
                            unlocked.MoneyTiers++;
                            changed = true;
                        }
                        break;
                    case 3:
                        if (unlocked.GameCurrency >= (int)MoneyUpgrade_Prices.tier4)
                        {
                            unlocked.GameCurrency -= (int)MoneyUpgrade_Prices.tier4;
                            unlocked.MoneyTiers++;
                            changed = true;
                        }
                        break;
                }
            }
            if(changed)
            {
                try
                {
                    await service1.UpdateUnlockedAsync(unlocked.UserId, unlocked);
                    CreateHealthSquares();
                    CreateMoneySquares();
                }
                catch (Exception ex)
                {
                    MessageDialog die = new MessageDialog(ex.Message);
                    await die.ShowAsync();
                }
            }
        }

        private void CreateMoneySquares()
        {
            Fair_Enough1.Children.Clear(); // Clear existing rectangles

            // Create squares based on unlocked MoneyTiers
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5),
                    Fill = (i < unlocked.MoneyTiers) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray)
                };
                Fair_Enough1.Children.Add(rectangle);
            }
        }

        private void CreateHealthSquares()
        {
            Fair_Enough2.Children.Clear(); // Clear existing rectangles

            // Create squares based on unlocked HealthTiers
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5),
                    Fill = (i < unlocked.HealthTiers) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray)
                };
                Fair_Enough2.Children.Add(rectangle);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                service1 = new DabloonsDB.Service1Client();
                User user = LoginPage.currentUser;
                unlocked = await service1.GetUnlockedAsync(user.UserId);

                CreateMoneySquares();
                CreateHealthSquares();
            }
            catch(Exception ex)
            {
                MessageDialog die = new MessageDialog(ex.Message);
                await die.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }
    }
}
