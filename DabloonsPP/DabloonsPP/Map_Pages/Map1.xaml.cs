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
    
    public sealed partial class Map1 : Page
    {
        #region constants
        const int STARTING_X = -50;
        const int STARTING_Y = 320;
        #endregion


        public Queue<Turn> turns = new Queue<Turn>();
        uint round = 1;
        public Map1()
        {
            this.InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            #region Initialize Turns
            turns.Enqueue(new Turn(turn1, Direction.Down));
            turns.Enqueue(new Turn(turn2, Direction.Right));
            turns.Enqueue(new Turn(turn3, Direction.Up));
            turns.Enqueue(new Turn(turn4, Direction.Right));
            turns.Enqueue(new Turn(turn5, Direction.Down));
            #endregion

            IEnemy enemy = new IEnemy(STARTING_X, STARTING_Y, "Assets\\StoreLogo.png", GameCanva, 25, 25, 1, turns);
        }
    }
}
