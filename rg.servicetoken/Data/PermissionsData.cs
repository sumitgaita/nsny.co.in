using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class PermissionsData
    {
        Factory myFactory;
        Helpers hlpr;

        public PermissionsData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public List<Permissions> GetAllPermissions()
        {
            List<Permissions> permissions = new List<Permissions>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "permissionListing";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                permissions.Add(new Permissions()
                {
                   

                    PermissionId = Convert.ToInt32(row["permission_id"]),
                    PermissionUserType = row["permission_user_type"].ToString(),
                    PermissionLoginType = Convert.ToInt32(row["login_id"]),
                    PermissionProjectId = Convert.ToInt32(row["ProjectID"]),
                    
                    PermissionLoginName = row["login_name"].ToString(),
                    PermissionProjectName = row["project_name"].ToString(),
                    PermissionForView = row["permission_for_view"].ToString(),
                    PermissionForAdd = row["permission_for_add"].ToString(),
                    PermissionForEdit = row["permission_for_edit"].ToString(),
                     PermissionForDelete = row["permission_for_delete"].ToString()


                });
            }
            return permissions;

        }

        public Permissions EditPermissionDetails(Permissions per)
        {
            var details = new Permissions();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@permission_id", per.PermissionId));
            string query = "EditProjectAssignList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.PermissionId = Convert.ToInt32(row["permission_id"]);
                details.PermissionUserType = row["permission_user_type"].ToString();
                details.PermissionForView = row["permission_for_view"].ToString();
                details.PermissionProjectName = row["project_name"].ToString();
                details.PermissionLoginName = row["login_name"].ToString();
                details.PermissionCreateDate = Convert.ToDateTime(row["login_create_date"]);
                details.PermissionLoginType = Convert.ToInt32(row["permission_login_type"]);
                
            }
            return details;

        }

        public bool CreatePermission(Permissions per)
        {
           
            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@permission_user_type", per.PermissionUserType));
            parameters.Add(myFactory.GetParameter("@permission_login_type", per.PermissionLoginType));
            parameters.Add(myFactory.GetParameter("@permission_project_id", per.PermissionProjectId));
            parameters.Add(myFactory.GetParameter("@permission_for_view", per.PermissionForView));
            parameters.Add(myFactory.GetParameter("@permission_for_add", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_for_edit", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_for_delete", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_create_date", per.PermissionCreateDate));
            //return hlpr.ExecuteDmlQuery("Add_New_user", ref parameters); 
            return hlpr.ExecuteStoredProcedure("Add_assignValue", ref parameters);
        }
        public bool UpdatePermission(Permissions per)
        {

           List <IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(myFactory.GetParameter("@permission_id", per.PermissionId));
            parameters.Add(myFactory.GetParameter("@permission_for_view", per.PermissionForView));
            parameters.Add(myFactory.GetParameter("@permission_project_id", per.PermissionProjectId));
            parameters.Add(myFactory.GetParameter("@permission_for_add", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_for_edit", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_for_delete", "Flase"));
            parameters.Add(myFactory.GetParameter("@permission_create_date", per.PermissionCreateDate));
            //return hlpr.ExecuteDmlQuery("update_User_Details", ref parameters);
            return hlpr.ExecuteStoredProcedure("updateAssignValue", ref parameters);
        }
        public bool UpdatePermissionForUserChangePermission(Permissions per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@permission_login_type", per.PermissionLoginType));
            parameters.Add(myFactory.GetParameter("@permission_user_type", per.PermissionUserType));
            
            //return hlpr.ExecuteDmlQuery("update_User_Details", ref parameters);
            return hlpr.ExecuteStoredProcedure("updateUserPermission", ref parameters);
        }
        
        public bool DeletePermission(Permissions per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(myFactory.GetParameter("@permission_id", per.PermissionId));
            //return hlpr.ExecuteDmlQuery("DeleteUserDetails", ref parameters);
            return hlpr.ExecuteStoredProcedure("DeleteAssignDetails", ref parameters);

        }

    }
}