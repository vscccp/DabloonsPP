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
    }

    
}
