using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSite
{
    public class User
    {
        public string AccountType { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public User CreateUser(User user)
        {
            return user;
        }

        public User ModifyAccount(User user)
        {
            return user;
        }

        public User UserLogin(User user)
        {
            return user;
        }

        public void UserLogout()
        {

        }
    }
}