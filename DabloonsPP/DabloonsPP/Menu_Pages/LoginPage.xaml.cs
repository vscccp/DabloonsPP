using DabloonsPP.DabloonsDB;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DabloonsPP.Assets.Menu_Pages
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public static User currentUser; 
            
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string pwd = PwdBox.Password;


            try
            {
                DabloonsDB.Service1Client service = new DabloonsDB.Service1Client();
                User user = new User();
                user.Username = username;
                user.Password = pwd;
                bool result = await service.TryLoginAsync(user);
                user.Password = "";

                
                if (result)
                {
                    currentUser = await service.GetUserByUsernameAsync(user.Username);
                    Frame.Navigate(typeof(MenuPage));
                }
                else
                {
                    throw new Exception("Wrong credentials");
                }
        }
            catch (Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
