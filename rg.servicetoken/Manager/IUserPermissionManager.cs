using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface IUserPermissionManager
    {

        bool CreateUserPermission(UserPermission userPermission);
        bool UpdateUserPermission(UserPermission userPermission);
        bool DeleteUserPermission(UserPermission userPermission);
        List<UserPermission> GetAllPermission();

    }
}