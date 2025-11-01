using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IPermissionsManager
    {
        List<Permissions> GetAllPermissions();
        Permissions EditPermissionDetails(Permissions per);
        bool CreatePermission(Permissions per);
        bool UpdatePermission(Permissions per);
        bool DeletePermission(Permissions per);
    }
}