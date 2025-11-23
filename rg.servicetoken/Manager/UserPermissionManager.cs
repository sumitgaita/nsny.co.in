using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class UserPermissionManager : IUserPermissionManager
    {
        public List<UserPermission> GetAllPermission()
        {
            UserPermissionData data = new UserPermissionData();
            return data.GetAllPermission();
        }

        public bool CreateUserPermission(UserPermission userPermission)
        {
            UserPermissionData data = new UserPermissionData();
            return data.CreateUserPermission(userPermission);
        }

        public bool UpdateUserPermission(UserPermission userPermission)
        {
            UserPermissionData data = new UserPermissionData();
            return data.UpdateUserPermission(userPermission);

        }

        public bool DeleteUserPermission(UserPermission userPermission)
        {
            UserPermissionData data = new UserPermissionData();
            return data.DeleteUserPermission(userPermission);

        }

        
    }
}