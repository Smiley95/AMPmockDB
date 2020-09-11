using System;
using System.Collections.Generic;
using System.Linq;
using AMPmockDB.Models;
using System.Web;
using AMPmockDB.DBContext;

namespace AMPmockDB.Repositories
{
    public class UserRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        APMDBEntities context = new APMDBEntities();
        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            return context.User.FirstOrDefault(user =>
            user.user_email.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.user_pwd == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}