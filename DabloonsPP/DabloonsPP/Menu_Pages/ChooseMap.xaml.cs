using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DabloonsPP.Assets.Menu_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseMap : Page
    {
        DabloonsDB.Unlocked unlocked;
        DabloonsDB.IService1 service1;

        public ChooseMap()
        {
            this.InitializeComponent();
        }

        private void SetMapImages(int unlockedMapsCount)
        {
            unlockedMapsCount++;
            // Define the paths for locked and unlocked map images
            string lockedMapPath = "/Assets/Maps/locked_map.jpg";
            string[] unlockedMapPaths = new string[]
            {
                "/Assets/Maps/map1.png",
                "/Assets/Maps/map2.png",
                "/Assets/Maps/map3.png"
            };

            // Check if unlockedMapsCount is within the range of available map images
            if (unlockedMapsCount >= 0 && unlockedMapsCount <= unlockedMapPaths.Length)
            {
                // Set the source for map images based on the unlocked maps count
                for (int i = 0; i < unlockedMapPaths.Length; i++)
                {
                    Image mapImage = (Image)Choice_Grid.Children[i];
                    if (i < unlockedMapsCount)
                    {
                        // Set the source to unlocked map
                        mapImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri(unlockedMapPaths[i]));
                    }
                    else
                    {
                        // Set the source to locked map
                        mapImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri(lockedMapPath));
                    }
                }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                service1 = new DabloonsDB.Service1Client();
                DabloonsDB.User user = LoginPage.currentUser;
                unlocked = await service1.GetUnlockedAsync(user.UserId);

                SetMapImages(unlocked.MapsUnlocked);
            }
            catch (Exception ex)
            {
                MessageDialog die = new MessageDialog(ex.Message);
                await die.ShowAsync();
            }
        }
    }
}
