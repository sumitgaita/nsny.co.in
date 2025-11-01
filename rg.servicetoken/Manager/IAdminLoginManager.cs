using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IAdminLoginManager
    {

        AdminLogin LoginDetails(AdminLogin login);
        bool ChangeBranchPassword(int id, string password);
        bool ChangeAdminPassword(int id, string username, string password);
        // List<User> GetAllUsers();

        //  bool ChangePassword(User login);
        //User UserDetails(User login);
        //bool CreateUser(User users);
        //bool UpdateUser(User users);

        //bool DeleteUser(User users);
    }
}