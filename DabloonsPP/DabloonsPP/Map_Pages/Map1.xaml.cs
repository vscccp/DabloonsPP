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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DabloonsPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map1 : Page
    {
        public List<Turn> turns = new List<Turn>();
        uint round = 1;
        public Map1()
        {
            this.InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            #region Initialize Turns
            turns.Add(new Turn(turn1, Direction.Down));
            turns.Add(new Turn(turn2, Direction.Right));
            turns.Add(new Turn(turn3, Direction.Up));
            turns.Add(new Turn(turn4, Direction.Right));
            turns.Add(new Turn(turn5, Direction.Down));
            #endregion

        
        }
    }
}
