using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class PermissionsManager: IPermissionsManager
    {
        
             public List<Permissions> GetAllPermissions()
        {
            var data = new PermissionsData();

            return data.GetAllPermissions();
        }

        public Permissions EditPermissionDetails(Permissions per)
        {
            var data = new PermissionsData();
            return data.EditPermissionDetails(per);
        }

        public bool CreatePermission(Permissions per)
        {
            var data = new PermissionsData();
            return data.CreatePermission(per);
        }

        public bool UpdatePermission(Permissions per)
        {
            var data = new PermissionsData();
            return data.UpdatePermission(per);
        }

        public bool DeletePermission(Permissions per)
        {
            var data = new PermissionsData();
            return data.DeletePermission(per);
        }
    }
}