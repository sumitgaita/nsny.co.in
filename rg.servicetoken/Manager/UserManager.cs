using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class UserManager: IUserManager
    {
        public User LoginDetails(User login)
        {
            var data = new UserData();

            return data.LoginDetails(login);
        }
        public List<User> GetAllUsers()
        {
            var data = new UserData();

            return data.GetAllUsers();
        }

        public bool ChangePassword(User login)
        {
            var data = new UserData();
            return data.ChangePassword(login);
        }

        public User UserDetails(User login)
        {
            var data = new UserData();
            return data.UserDetails(login);
        }

        public bool CreateUser(User users)
        {
            var data = new UserData();
            return data.CreateUser(users);
        }

        public bool UpdateUser(User users)
        {
           var data = new UserData();
           var userUpade= data.UpdateUser(users);
            if (userUpade)
            {
                var data1 = new PermissionsData();
                var obj = new Permissions();
                obj.PermissionLoginType = users.LoginId;
                obj.PermissionUserType = users.LoginUserType;
                var userPermissionUpade = data1.UpdatePermissionForUserChangePermission(obj);
            }
            return true;
        }
        private bool UpdatePermission(Permissions per)
        {
            var data = new PermissionsData();
            return data.UpdatePermission(per);
        }
        public bool DeleteUser(User users)
        {
            var data = new UserData();
            return data.DeleteUser(users);
        }

    }
}