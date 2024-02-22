using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dabloons_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private const string ConnectionString = @"Data Source=CEC-MAGSHIMIM;Initial Catalog=DabloonsDB;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(ConnectionString);

        #region basic queries
        public bool AddUser(User user)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", connection);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();

                AddUnlocked(GetUserByUsername(user.Username).UserId);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        UserId = Convert.ToInt32(reader["UserId"])
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        UserId = Convert.ToInt32(reader["UserId"])
                    });
                }
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @Password WHERE Username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool TryLogin(User user)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", connection);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddMatch(int userId, Matches match)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Match (UserId, TimeTaken, MoneyAccumulated, TowersBuilt, Result) " +
                                                "VALUES (@UserId, @TimeTaken, @MoneyAccumulated, @TowersBuilt, @Result)", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@TimeTaken", match.TimeTaken);
                cmd.Parameters.AddWithValue("@MoneyAccumulated", match.MoneyAccumulated);
                cmd.Parameters.AddWithValue("@TowersBuilt", match.TowersBuilt);
                cmd.Parameters.AddWithValue("@Result", match.Result);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddUnlocked(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Unlocked (UserId) VALUES (@UserId)", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateUnlocked(int userId, Unlocked unlocked)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Unlocked SET GameCurrency = @GameCurrency, " +
                                                "MapsUnlocked = @MapsUnlocked, " +
                                                "MoneyTiers = @MoneyTiers, " +
                                                "HealthTiers = @HealthTiers " +
                                                "WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@GameCurrency", unlocked.GameCurrency);
                cmd.Parameters.AddWithValue("@MapsUnlocked", unlocked.MapsUnlocked);
                cmd.Parameters.AddWithValue("@MoneyTiers", unlocked.MoneyTiers);
                cmd.Parameters.AddWithValue("@HealthTiers", unlocked.HealthTiers);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteMatch(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Match WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@MatchId", userId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteUnlockables(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Unlocked WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                connection.Open();

                // Delete unlockables
                DeleteUnlockables(userId);

                DeleteMatch(userId);

                // Delete user
                SqlCommand deleteUserCmd = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", connection);
                deleteUserCmd.Parameters.AddWithValue("@UserId", userId);
                deleteUserCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region Personal Stats
        public int GetTotalGamesCount(int UserId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Match WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@Username", UserId);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetTotalMoneySpent(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(MoneyAccumulated) FROM Match WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetTotalMoneyGained(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(MoneyAccumulated) FROM Match WHERE UserId = @UserId AND Result = 'W'", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetTotalTowersBuilt(int userId)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(TowersBuilt) FROM Match WHERE UserId = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            finally
            {
                connection.Close();
            }
        }

#endregion

        #region Top Stats
        public User GetTopPlayerByMoneySpent()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, SUM(m.MoneyAccumulated) AS TotalMoneySpent " +
                                                "FROM Users u " +
                                                "INNER JOIN Match m ON u.UserId = m.UserId " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY TotalMoneySpent DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetTopPlayerByMoneyGained()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, SUM(m.MoneyAccumulated) AS TotalMoneyGained " +
                                                "FROM Users u " +
                                                "INNER JOIN Match m ON u.UserId = m.UserId " +
                                                "WHERE m.Result = 'W' " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY TotalMoneyGained DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetTopPlayerByTowersBuilt()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, SUM(m.TowersBuilt) AS TotalTowersBuilt " +
                                                "FROM Users u " +
                                                "INNER JOIN Match m ON u.UserId = m.UserId " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY TotalTowersBuilt DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetPlayerWithFastestGame()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, MIN(m.TimeTaken) AS FastestTime " +
                                                "FROM Users u " +
                                                "INNER JOIN Match m ON u.UserId = m.UserId " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY FastestTime ASC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetPlayerWithMostLosses()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, COUNT(m.Result) AS LossCount " +
                                                "FROM Users u " +
                                                "LEFT JOIN Match m ON u.UserId = m.UserId AND m.Result = 'L' " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY LossCount DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetPlayerWithMostWins()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, COUNT(m.Result) AS WinCount " +
                                                "FROM Users u " +
                                                "LEFT JOIN Match m ON u.UserId = m.UserId AND m.Result = 'W' " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY WinCount DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetPlayerWithBestWinPercentage()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, " +
                                                "CAST(COUNT(CASE WHEN m.Result = 'W' THEN 1 END) AS FLOAT) / " +
                                                "NULLIF(COUNT(*), 0) AS WinPercentage " +
                                                "FROM Users u " +
                                                "LEFT JOIN Match m ON u.UserId = m.UserId " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY WinPercentage DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetPlayerWithBestLossPercentage()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 u.UserId, u.Username, " +
                                                "CAST(COUNT(CASE WHEN m.Result = 'L' THEN 1 END) AS FLOAT) / " +
                                                "NULLIF(COUNT(*), 0) AS LossPercentage " +
                                                "FROM Users u " +
                                                "LEFT JOIN Match m ON u.UserId = m.UserId " +
                                                "GROUP BY u.UserId, u.Username " +
                                                "ORDER BY LossPercentage ASC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
