using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class UserPermissionData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public UserPermissionData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateUserPermission(UserPermission userPermission)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@username", userPermission.Username),
                myFactory.GetParameter("@pass", userPermission.Pass),
                myFactory.GetParameter("@name", userPermission.Name),
                myFactory.GetParameter("@addcatagory", userPermission.Addcatagory),
                myFactory.GetParameter("@editcatagory", userPermission.Editcatagory),
                myFactory.GetParameter("@addcourse", userPermission.Addcourse),
                myFactory.GetParameter("@editcourse", userPermission.Editcourse),
                myFactory.GetParameter("@addbranch", userPermission.Addbranch),
                myFactory.GetParameter("@editbranch", userPermission.Editbranch),
                myFactory.GetParameter("@editstudent", userPermission.Editstudent),
                myFactory.GetParameter("@editbranchstudentbind", userPermission.Editbranchstudentbind),
                myFactory.GetParameter("@noticetobranch", userPermission.Noticetobranch),
                myFactory.GetParameter("@allnoticetobranch", userPermission.Allnoticetobranch),
                myFactory.GetParameter("@studentregistration", userPermission.Studentregistration),
                myFactory.GetParameter("@studenticard", userPermission.Studenticard),
                myFactory.GetParameter("@active", userPermission.Active)
               
            };
            return hlpr.ExecuteStoredProcedure("UserPermission", ref parameters);
        }
      
        public bool UpdateUserPermission(UserPermission userPermission)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", userPermission.Id),
                myFactory.GetParameter("@username", userPermission.Username),
                myFactory.GetParameter("@pass", userPermission.Pass),
                myFactory.GetParameter("@name", userPermission.Name),
                myFactory.GetParameter("@addcatagory", userPermission.Addcatagory),
                myFactory.GetParameter("@editcatagory", userPermission.Editcatagory),
                myFactory.GetParameter("@addcourse", userPermission.Addcourse),
                myFactory.GetParameter("@editcourse", userPermission.Editcourse),
                myFactory.GetParameter("@addbranch", userPermission.Addbranch),
                myFactory.GetParameter("@editbranch", userPermission.Editbranch),
                myFactory.GetParameter("@editstudent", userPermission.Editstudent),
                myFactory.GetParameter("@editbranchstudentbind", userPermission.Editbranchstudentbind),
                myFactory.GetParameter("@noticetobranch", userPermission.Noticetobranch),
                myFactory.GetParameter("@allnoticetobranch", userPermission.Allnoticetobranch),
                myFactory.GetParameter("@studentregistration", userPermission.Studentregistration),
                myFactory.GetParameter("@studenticard", userPermission.Studenticard),
                myFactory.GetParameter("@active", userPermission.Active)
             };
            return hlpr.ExecuteStoredProcedure("UserPermissionUpdate", ref parameters);

        }

        public bool DeleteUserPermission(UserPermission userPermission)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", userPermission.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteUserPermission", ref parameters);

        }
       
        public List<UserPermission> GetAllPermission()
        {
            List<UserPermission> brach = new List<UserPermission>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetUserPermissionList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                brach.Add(new UserPermission()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Username = row["username"].ToString(),
                    Pass = row["pass"].ToString(),
                    Name = row["name"].ToString(),
                    Addcatagory = row["addcatagory"] != DBNull.Value  ? Convert.ToBoolean(row["addcatagory"]) : (bool)false,
                    Editcatagory = row["editcatagory"] != DBNull.Value ? Convert.ToBoolean(row["editcatagory"]) : (bool)false,
                    Addcourse = row["addcourse"] != DBNull.Value ? Convert.ToBoolean(row["addcourse"]) : (bool)false,
                    Editcourse = row["editcourse"] != DBNull.Value ? Convert.ToBoolean(row["editcourse"]) : (bool)false,
                    Addbranch = row["addbranch"] != DBNull.Value ? Convert.ToBoolean(row["addbranch"]) : (bool)false,
                    Editbranch = row["editbranch"] != DBNull.Value ? Convert.ToBoolean(row["editbranch"]) : (bool)false,
                    Editstudent = row["editstudent"] != DBNull.Value ? Convert.ToBoolean(row["editstudent"]) : (bool)false,
                    Editbranchstudentbind = row["editbranchstudentbind"] != DBNull.Value ? Convert.ToBoolean(row["editbranchstudentbind"]) : (bool)false,
                    Noticetobranch = row["noticetobranch"] != DBNull.Value ? Convert.ToBoolean(row["noticetobranch"]) : (bool)false,
                    Allnoticetobranch = row["allnoticetobranch"] != DBNull.Value ? Convert.ToBoolean(row["allnoticetobranch"]) : (bool)false,
                    Studentregistration = row["studentregistration"] != DBNull.Value ? Convert.ToBoolean(row["studentregistration"]) : (bool)false,
                    Studenticard = row["studenticard"] != DBNull.Value ? Convert.ToBoolean(row["studenticard"]) : (bool)false,
                    Active = row["active"] != DBNull.Value ? Convert.ToBoolean(row["active"]) : (bool)false

                });
            }
            return brach;
        }
       
    }
}