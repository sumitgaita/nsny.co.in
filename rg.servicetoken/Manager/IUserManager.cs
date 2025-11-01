using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IUserManager
    {

         User LoginDetails(User login);
           List<User> GetAllUsers();

          bool ChangePassword(User login);
        User UserDetails(User login);
        bool CreateUser(User users);
        bool UpdateUser(User users);

        bool DeleteUser(User users);
    }
}