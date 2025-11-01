using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class Permissions
    {
        public int PermissionId { get; set; }
        public string PermissionUserType { get; set; }
        public int PermissionLoginType { get; set; }
        public int PermissionProjectId { get; set; }
        public string PermissionForView { get; set; }
        public string PermissionForAdd { get; set; }
        public string PermissionForEdit { get; set; }
        public string PermissionForDelete { get; set; }
        public string PermissionLoginName { get; set; }
        public string PermissionProjectName { get; set; }
        public DateTime PermissionCreateDate { get; set; }


    }
}