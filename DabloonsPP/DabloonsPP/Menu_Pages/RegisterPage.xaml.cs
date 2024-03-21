using DabloonsPP.DabloonsDB;
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

namespace DabloonsPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string pwd = PwdBox.Password;

            if(username.Length < 5 || username.Length > 16)
            {
                MessageDialog message = new MessageDialog("Username length is invalid(Should be between 5-16)");
                await message.ShowAsync();
            }
            else if((pwd.Length < 6 || pwd.Length > 24))
            {
                MessageDialog message = new MessageDialog("Password length is invalid(Should be between 6-24)");
                await message.ShowAsync();
            }
            else
            {
                try
                {
                    DabloonsDB.Service1Client service = new DabloonsDB.Service1Client();
                    User user = new User();
                    user.Username = username;
                    user.Password = pwd;
                    User result = await service.GetUserByUsernameAsync(user.Username);
                    
                    if(result == null)
                    {
                        bool addResult = await service.AddUserAsync(user);
                        if(addResult)
                        {
                            Frame.Navigate(typeof(MainPage));
                        }
                        else
                        {
                            throw new Exception("Add user to DB failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Username already exists.");
                    }
                }
                catch(Exception ex)
                {
                    MessageDialog message = new MessageDialog(ex.Message);
                    await message.ShowAsync();
                }
            }

            

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
