using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dabloons_Service
{
    [ServiceContract]
    public interface IService1
    {
        #region basic queries
        [OperationContract]
        bool TryLogin(User user);

        [OperationContract]
        User GetUserByUsername(string username);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        bool AddUnlocked(int userId);

        [OperationContract]
        bool UpdateUnlocked(int userId, Unlocked unlocked);

        [OperationContract]
        bool AddMatch(int userId, Matches match);

        [OperationContract]
        bool DeleteMatch(int matchId);

        [OperationContract]
        bool DeleteUnlockables(int userId);

        [OperationContract]
        bool DeleteUser(int userId);
        #endregion

        #region Personal stats
        // Personal stats of a current player
        [OperationContract]
        int GetTotalGamesCount(int userId);

        [OperationContract]
        int GetTotalMoneySpent(int userId);

        [OperationContract]
        int GetTotalMoneyGained(int userId);

        [OperationContract]
        int GetTotalTowersBuilt(int userId);
#endregion

        #region Top Stats
        [OperationContract]
        User GetTopPlayerByMoneySpent();

        [OperationContract]
        User GetTopPlayerByMoneyGained();

        [OperationContract]
        User GetTopPlayerByTowersBuilt();

        [OperationContract]
        User GetPlayerWithFastestGame();

        [OperationContract]
        User GetPlayerWithMostLosses();

        [OperationContract]
        User GetPlayerWithMostWins();

        [OperationContract]
        User GetPlayerWithBestWinPercentage();

        [OperationContract]
        User GetPlayerWithBestLossPercentage();

        #endregion
    }
}
