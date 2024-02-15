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
        private AddMoneyForPop addMoney;
        private List<Bloon> enemies;

        private DispatcherTimer enemyChecker;

        public RoundManager(Canvas gameCanvas, AddMoneyForPop addMoney, List<Bloon> enemies)
        {
            this.gameCanva = gameCanvas;
            this.addMoney = addMoney;
            this.enemies = enemies;

            enemyChecker.Tick += EnemyChecker_Tick;
            enemyChecker.Interval = TimeSpan.FromSeconds(1);
        }

        private void EnemyChecker_Tick(object sender, object e)
        {
            if (enemies.Count == 0)
            {
                round++;
                enemyChecker.Stop();
            }
        }

        public void startRound()
        {




            enemyChecker.Start();
        }

        
    }
}
